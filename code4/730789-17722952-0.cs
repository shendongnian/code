    using System;
    using System.Text.RegularExpressions;
    namespace TestsApplication
    {
        class Program
        {
            static void Main(string[] args)
            {
                string sPattern = "197.168.178.([1-9]|10)$";
                string[] IPs = 
                    {
                        "197.168.178.1",
                        "197.168.178.10",
                        "197.168.178.5",
                        "197.168.178.255",
                        "255.255.255.0"
                    };
                foreach (string s in IPs)
                {
                    Console.Write("{0,24}", s);
                    if (Regex.IsMatch(s, sPattern, RegexOptions.IgnoreCase))
                        Console.WriteLine("  (match for '{0}' found)", sPattern);
                    else
                        Console.WriteLine("  No match!");
                }
                Console.ReadLine(); //Pause
            }
        }
    }
