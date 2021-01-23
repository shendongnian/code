    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string test = "/store/457987680928164?id=2";
                int start = test.IndexOfAny("0123456789".ToCharArray());
                int end = test.IndexOf("?");
    
                Console.WriteLine(test.Substring(start, end - start));
    
                Console.ReadLine();
            }
        }
    }
