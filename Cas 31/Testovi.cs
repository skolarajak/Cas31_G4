using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using System.IO;

namespace Cas_31
{
    class Testovi
    {
        //definisanje i inizijalizacija promenljivih
        IWebDriver driver;
        
        //setup
        [SetUp]
        //metoda koja inicijalizuje promenljivu driver na novu instancu firefox instance
        public void OpenBrowser()
        {
            driver = new FirefoxDriver();
        }

        public void GoToURL(string url)
        {
            this.driver.Url = url;
        }

        [Test]
        public void Cas30Test1()
        {
            GoToURL("https://www.seleniumeasy.com/test/basic-radiobutton-demo.html");
            Thread.Sleep(5000);

            //definicija elemenata
            IWebElement radiogroupF = driver.FindElement(By.XPath("//input[@value='Female' and @name='optradio']"));
            IWebElement button = driver.FindElement(By.Id("buttoncheck"));


            radiogroupF.Click();
            button.Click();

            Thread.Sleep(2000);

            IWebElement message1 = driver.FindElement(By.XPath("//p[contains(.,'Radio button')]"));

            //1vi nacin potvrde da je poruka ispisana
            bool chk1 = message1.Displayed;

            //2gi nacin potvrde da je pravilna poruka ispisana
            //iscitavanje texta poruke i smestanje u promenljivu txt
            String txt = message1.Text;

            //iscitavanje value atributa i smestanje u promenljivu
            String pol = radiogroupF.GetAttribute("value");

            //kreiranje tri promenljive, cijim spajanjem cemo dobiti tekst ocekivane poruke
            String var1 = "Radio button ";
            String var2 = "'" + pol + "'";
            String var3 = " is checked";

            bool chk2 = txt.Contains(var1 + var2 + var3);
            if (chk2) {
                System.IO.File.AppendAllText(@"C:\SeleniumTxt\log.txt", DateTime.Now + "Poruka je prikazana, " + chk2 + Environment.NewLine);
            }
            else
            {
                System.IO.File.AppendAllText(@"C:\SeleniumTxt\log.txt", DateTime.Now + "Poruka je prikazana, " + chk2 + Environment.NewLine);
            }

        }

        [Test]


        [TearDown]
        public void CloseBrowser()
        {
            driver.Close();
        }

    }
}
