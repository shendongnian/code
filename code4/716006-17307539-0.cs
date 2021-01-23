    using System;
    using System.Diagnostics;
    
    namespace Sandbox_Console
    {
        class A
        {
        }
    
        internal static class Program
        {
            static bool F<T>(T a, T b) where T : class
            {
                return a == b;
            }
    
            static bool F2(A a, A b)
            {
                return a == b;
            }
    
            private static void Main()
            {
                var a = new A();
                Stopwatch st = new Stopwatch();
    
                Console.WriteLine("warmup");
                st.Start();
                for (int i = 0; i < 100000000; i++)
                    F<A>(a, a);
                Console.WriteLine(st.Elapsed);
    
                st.Restart();
                for (int i = 0; i < 100000000; i++)
                    F2(a, a);
                Console.WriteLine(st.Elapsed);
    
                Console.WriteLine("real");
                st.Restart();
                for (int i = 0; i < 100000000; i++)
                    F<A>(a, a);
                Console.WriteLine(st.Elapsed);
    
                st.Restart();
                for (int i = 0; i < 100000000; i++)
                    F2(a, a);
                Console.WriteLine(st.Elapsed);
    
                Console.WriteLine("Done");
                Console.ReadLine();
            }
    
        }
    }
