    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Diagnostics;
    namespace TestProject1
    {
    public class DataObject
    {
        public string A { get; set; }
        public string B { get; set; }
        public string C { get; set; }
        public string D { get; set; }
        public string E { get; set; }
        public string F { get; set; }
    }
    [TestClass]
    public class UnitTest1
    {
        public static Dictionary<string, DataObject> dict = new Dictionary<string, DataObject>();
        static string lookie;
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext) {
            Random rand = new Random(123545);
            for (int i = 0; i < 10000; i++)
            {
                string key = rand.NextDouble().ToString();
                DataObject dob = new DataObject();
                dict.Add(key, dob);
                if (i == 4567)
                    lookie = key;
            }
         
        }
        [TestMethod]
        public void TestMethod()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int j = 0; j < 100000; j++)
            {
                dict[lookie].A = "val" + j;
                dict[lookie].B = "val" + j;
                dict[lookie].C = "val" + j;
                dict[lookie].D = "val" + j;
                dict[lookie].E = "val" + j;
                dict[lookie].F = "val" + j;
            }
            sw.Stop();
            System.Diagnostics.Debug.WriteLine(sw.ElapsedMilliseconds);
            sw.Reset();
            sw.Start();
            for (int j = 0; j < 100000; j++)
            {
                DataObject dob = dict[lookie];
                dob.A = "val" + j;
                dob.B = "val" + j;
                dob.C = "val" + j;
                dob.D = "val" + j;
                dob.E = "val" +j;
                dob.F = "val" +j;
            }
            sw.Stop();
            System.Diagnostics.Debug.WriteLine(sw.ElapsedMilliseconds);
        }
      }
    }
