        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Text;
        namespace ConsoleApplication1
        {
            class Program
            {
                static void Main(string[] args)
                {
                    ParseAndOutput("");
                    ParseAndOutput("1.0");
                    ParseAndOutput("ABC");
                }
                private static void ParseAndOutput(string input)
                {
                    double value = -1;
                    if (double.TryParse(input, out value))
                    {
                        Console.WriteLine("Parse succeeded for '"+input+"', try parse changed to: " + value);
                    }
                    else
                    {
                        Console.WriteLine("Parse failed for '" + input + "', try parse changed to:  " + value);
                    }
                }
            }
        }
