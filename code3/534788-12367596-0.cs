    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Security.Cryptography;
    
    namespace LinqRandomString
    {
        class Program
        {
            static void Main(string[] args)
            {
                do
                {
                    byte[] random = new byte[10000];
                    
                    using (var rng = RandomNumberGenerator.Create())
                        rng.GetBytes(random);
    
    
                    var q = random
                                .Where(i => (i >= 65 && i <= 90) || (i >= 97 && i <= 122)) // ascii ranges - change to include symbols etc
                                .Take(10) // first 10
                                .Select(i => Convert.ToChar(i)); // convert to a character
    
                    foreach (var c in q)
                        Console.Write(c);
    
                } while (Console.ReadLine() != "exit");
            }
        }
    }
