    using System;
    using System.Diagnostics;
    namespace Demo
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                var ar = new int[500000000];
                test1(ar);
                //ar = new int[500000000]; // Uncomment this line.
                test2(ar);
            }
            private static void test1(int[] ar)
            {
                var sw = new Stopwatch();
                sw.Start();
                var length = ar.Length;
                for (var i = 0; i < length; i++)
                {
                    if (ar[i] == 0);
                }
                sw.Stop();                
                Console.WriteLine("test1 took " + sw.Elapsed);
            }
            private static void test2(int[] ar)
            {
                var sw = new Stopwatch();
                sw.Start();
                for (var i = 0; i < ar.Length; i++)
                {
                    if (ar[i] == 0);
                }
                sw.Stop();
                Console.WriteLine("test2 took " + sw.Elapsed);
            }
        }
    }
