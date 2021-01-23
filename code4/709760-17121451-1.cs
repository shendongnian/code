    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Threading;
    namespace ConsoleApplication3
    {
    class Program
    {
        private static long i = 0;
        
        static void Main(string[] args)
        {
            Thread T = new Thread(DoSomething, 100000000);
            T.Start();
            Console.ReadLine();
            
        }
        public static void DoSomething()
        {
            Console.WriteLine(i);
            ++i;
            DoSomething();
        }
       
     }
    }
