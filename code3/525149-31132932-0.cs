    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NUnit.Framework;
    using Sikuli4Net.sikuli_REST;
    using Sikuli4Net.sikuli_JSON;
    using Sikuli4Net.sikuli_UTIL;
    using System.Threading;
    using Newtonsoft.Json;
    
    namespace UnitTestProject3
    {
        [TestClass]
        public class UnitTest1
        {
            APILauncher launcher = new APILauncher();
    
            Pattern element1 = new Pattern(@"C:\myfolderforscreens\1.png");
            [Test]
            public void TestMethod1()
            {
                launcher.Start();
                
                Thread.Sleep(8000);
                Screen test = new Screen();
                
                test.DoubleClick(element1);
                
                
            }
        }
    }
