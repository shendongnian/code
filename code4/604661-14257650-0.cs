    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    
    namespace ProgramConsole
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                List<string> A = new List<string> { "Personal", "Tech", "Social" };
                List<string> B = new List<string> { "Personal", "Tech", "General" };
    
                var result = A.Except(B).ToList();
    
                foreach (var i in result)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
