    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Diagnostics;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                CallAsExpected();
                CallWithNull();
                CallNoHits();
                Console.WriteLine("Look at Debug Output");
                Console.ReadKey();
            }
            private static void CallNoHits()
            {
                TryCall(new List<string> {
                    "UK foo",
                    "DE bar"
                });
            }
            private static void CallWithNull()
            {
                TryCall(null);
            }
            private static void CallAsExpected()
            {
                TryCall(new List<string> {
                    "US woohooo",
                    "UK foo",
                    "DE bar",
                    "US second",
                    "US third"
                });
            }
            private static void TryCall(List<String> ghh)
            {
                try
                {
                    TestMethod(ghh);
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                }
            }
            private static void TestMethod(List<String> ghh)
            {
                if (ghh == null) Debug.WriteLine("ghh was null");
                var testVar = (from r in ghh
                               where (r.Contains("US"))
                               select r);
                Debug.WriteLine(String.Format("Items Found: {0}", testVar.Count()));
                if (testVar == null) Debug.WriteLine("testVar was null");
                foreach (String item in testVar)
                {
                    Debug.WriteLine(item);
                }
            }
        }
    }
