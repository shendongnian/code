    namespace SO10747736
    {
        using System;
    
        internal enum TestResult
        {
            TryCreatePass,
            ValidWithPrefix,
            Search,
            DoNothing,
            Unknown
        }
    
        public class Program
        {
            public static void Main(string[] args)
            {
                Test("http://example.com", TestResult.TryCreatePass);
                Test("https://example.com", TestResult.TryCreatePass);
                Test("https://example", TestResult.TryCreatePass);
                Test("example.com", TestResult.ValidWithPrefix);
                Test("example", TestResult.Search);
                Test("another example", TestResult.Search);
                Test(null, TestResult.DoNothing);
                Test(string.Empty, TestResult.DoNothing);
                Test("  ", TestResult.DoNothing);
                Test("about:blank", TestResult.DoNothing);
    
                Console.ReadKey(true);
            }
    
            private static void Test(string toTest, TestResult expectedResult)
            {
                var result = SimulateEnterkeyPressed(toTest);
    
                if (result == expectedResult)
                {
                    Console.WriteLine("{0} was parsed correctly", toTest);
                }
                else
                {
                    Console.WriteLine("*** {0} was NOT parsed correctly and returned {1} ***", toTest, result);
                }
            }
    
            private static TestResult SimulateEnterkeyPressed(string toTest)
            {
                if (string.IsNullOrWhiteSpace(toTest))
                {
                    return TestResult.DoNothing;
                }
    
                // Uri.TryCreate will treat this as valid
                if (toTest.Equals("about:blank"))
                {
                    return TestResult.DoNothing;
                }
    
                Uri url;
                if (Uri.TryCreate(toTest, UriKind.Absolute, out url))
                {
                    return TestResult.TryCreatePass;
                }
                else
                {
                    return TryParse(toTest);
                }
            }
    
            private static TestResult TryParse(string toTest)
            {
                if (!toTest.Contains("."))
                {
                    return TestResult.Search;
                }
    
                if (!toTest.StartsWith("http://") ||
                    !toTest.StartsWith("https://"))
                {
                    return TestResult.ValidWithPrefix;
                }
    
                return TestResult.Unknown;
            }
        }
    }
