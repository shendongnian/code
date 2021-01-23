    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.RegularExpressions;
    
    namespace Q11438740ConApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                string sourceStr = "1y 250 2y 32% 3y otherjibberish";
                Regex rx = new Regex(@"\d+y");
                string[] splitedArray = SplitByRegex(sourceStr, rx);
    
                for (int i = 0; i < splitedArray.Length; i++)
                {
                    Console.WriteLine(String.Format("'{0}'", splitedArray[i]));
                }
    
                Console.ReadLine();
            }
    
            public static string[] SplitByRegex(string input, Regex rx)
            {
                MatchCollection matches = rx.Matches(input);
                String[] outArray = new string[matches.Count];
                for (int i = 0; i < matches.Count; i++)
                {
                    int length = 0;
                    if (i == matches.Count - 1)
                    {
                        length = input.Length - (matches[i].Index + matches[i].Length);
                    }
                    else
                    {
                        length = matches[i + 1].Index - (matches[i].Index + matches[i].Length);
                    }
    
                    outArray[i] = matches[i].Value + input.Substring(matches[i].Index + matches[i].Length, length);
                }
    
                return outArray;
            }
        }
    }
