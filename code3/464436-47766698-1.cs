    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApp1
    {
        class Program
        {
           
           
            static void Main(string[] args)
            {
                Func<int, int> del = delegate (int x)
                  {
                      return x * x;
    
                  };
                 
                int p= del(4);
                Console.WriteLine(p);
                Console.ReadLine();
            }
        }
    }
