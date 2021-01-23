    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text.RegularExpressions;
    
    
    namespace FindTest
    {
        class Program
        {
            
    
            const int Iterations = 1000;
    
            static string TestData;
            static Regex regex;
            static bool ValidResult = false;
    
    
            static void Test(Func<string, bool> function)
            {
                Console.Write("{0}... ", function.Method.Name);
                Stopwatch sw = Stopwatch.StartNew();
                for (int i = 0; i < Iterations; i++)
                {
                    bool result = function(TestData);
                    if (result != ValidResult)
                    {
                        throw new Exception("Bad result: " + result);
                    }
                }
                sw.Stop();
                Console.WriteLine(" {0}ms", sw.ElapsedMilliseconds);
                GC.Collect();
            }
    
            static void InitializeTestDataEnd(int length)
            {
                TestData = new string(Enumerable.Repeat('1', length - 1).ToArray()) + "A";
            }
    
            static void InitializeTestDataStart(int length)
            {
                TestData = "A" + new string(Enumerable.Repeat('1', length - 1).ToArray());
            }
    
            static void InitializeTestDataMid(int length)
            {
                TestData = new string(Enumerable.Repeat('1', length / 2).ToArray()) + "A" + new string(Enumerable.Repeat('1', length / 2 - 1).ToArray());
            }
    
            static void InitializeTestDataPositive(int length)
            {
                TestData = new string(Enumerable.Repeat('1', length).ToArray());
            }
    
            static bool LinqScan(string s)
            {
                return s.All(Char.IsDigit);
            }
    
            static bool ForeachScan(string s)
            {
                foreach (char c in s)
                {
                    if (!Char.IsDigit(c))
                        return false;
                }
                return true;
            }
    
            static bool ForScan(string s)
            {
                for (int i = 0; i < s.Length; i++)
                {
                    if (!Char.IsDigit(s[i]))
                        return false;
                }
                return true;
            }
    
            static bool Regexp(string s)
            {
                // String contains numbers
                return regex.IsMatch(s);
    
               // String contains letters
               //return Regex.IsMatch(s, "\\w", RegexOptions.Compiled);
            }
    
            static void Main(string[] args)
            {
                regex = new Regex(@"^\d+$", RegexOptions.Compiled);
    
                Console.WriteLine("Positive (all digitis)");
    
                InitializeTestDataPositive(100000);
                ValidResult = true;            
    
                Test(LinqScan);
                Test(ForeachScan);
                Test(ForScan);
                Test(Regexp);
    
                Console.WriteLine("Negative (char at beginning)");
                InitializeTestDataStart(100000);
                ValidResult = false;            
    
                Test(LinqScan);
                Test(ForeachScan);
                Test(ForScan);
                Test(Regexp);
    
                Console.WriteLine("Negative (char at end)");
                InitializeTestDataEnd(100000);
                ValidResult = false;
    
                Test(LinqScan);
                Test(ForeachScan);
                Test(ForScan);
                Test(Regexp);
    
                Console.WriteLine("Negative (char in middle)");
                InitializeTestDataMid(100000);
                ValidResult = false;
    
                Test(LinqScan);
                Test(ForeachScan);
                Test(ForScan);
                Test(Regexp);
    
                Console.WriteLine("Done");
            }
        }
    }
