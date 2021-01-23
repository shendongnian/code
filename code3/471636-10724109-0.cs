    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Xml;       
    
    namespace TestProject1
    {
        [TestClass]
        public class UnitTest1
        {
            private const string testString = "Surfin&#39; USA";
            [TestMethod]
            public void TestMethod1()
            {
                XmlDocument xmlDoc = new XmlDocument();
                XmlText xmlMyText;
    
                xmlMyText = xmlDoc.CreateTextNode(testString);
    
                Assert.AreEqual(testString, xmlMyText.InnerText);
    
            }
        }
    }
