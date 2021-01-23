    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace ConsoleApplication1
    {
        class Program
        {
            static List<long> list = new List<long>();
            static void Main(string[] args)
            {
                //delegate
                Parallel.For(1023456789, 1033456789, delegate(long i)
                {
                    if (i % 10000000 == 0) Console.WriteLine("{0:N0}", i);
                    if (IsPanDigital(i))
                    {
                        list.Add(i);
                    }
                });
                //lambda expression
                Parallel.For(1023456789, 1033456789, i =>
                {
                    if (i % 10000000 == 0) Console.WriteLine("{0:N0}", i);
                    if (IsPanDigital(i))
                    {
                        list.Add(i);
                    }
                });
                Parallel.For(1023456789, 1033456789, Blah); //other overloads do accept other Actions
            }
            private static bool IsPanDigital(long i)
            {
                return false;
            }
            public static void Blah(int i) // = Action<int i>
            {
                if (i % 10000000 == 0) Console.WriteLine("{0:N0}", i);
                if (IsPanDigital(i))
                {
                    list.Add(i);
                }
            }
        }
    }
