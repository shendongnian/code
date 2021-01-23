        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Text;
        using System.Text.RegularExpressions;
        namespace ConsoleApplication1
        {
            class Program
            {
                static void Main(string[] args)
                {
                    string input = "asdf234!@#*advfk234098awfdasdfq9823fna943";
                    DateTime start = DateTime.Now;
                    for (int i = 0; i < 100000; i++)
                    {
                        RemoveNonUnicodeLetters(input);
                    }
                    Console.WriteLine(DateTime.Now.Subtract(start).TotalSeconds);
                    start = DateTime.Now;
                    for (int i = 0; i < 100000; i++)
                    {
                        RemoveNonUnicodeLetters2(input);
                    }
                    Console.WriteLine(DateTime.Now.Subtract(start).TotalSeconds);
                }
                public static string RemoveNonUnicodeLetters(string input)
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (char c in input)
                    {
                        if (Char.IsLetter(c))
                            sb.Append(c);
                    }
                    return sb.ToString();
                }
                public static string RemoveNonUnicodeLetters2(string input)
                {
                    var result = Regex.Replace(input, "\\P{L}", "");
                    return result;
                }
            }
        }
