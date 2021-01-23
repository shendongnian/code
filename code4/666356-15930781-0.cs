    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace stringlulz
    {
        class Program
        {
            static void Main(string[] args)
            {
                string original = "Test message";
    
                byte[] bytes = System.Text.Encoding.Unicode.GetBytes(original + '\0');
    
                var output = bytes.Aggregate(new StringBuilder(), (s, p) => s.Append(p.ToString("x2") + ' '), s => { s.Length--; return s; });
    
    
                Console.WriteLine(output.ToString().ToUpper());
                Console.ReadLine();
            }
        }
    }
