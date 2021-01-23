    using System;
    using System.Diagnostics;
    
    namespace ConsoleApplication5
    {
        public class X
        {
            private int _a;
            private int _b;
            
            public int A
            {
                get
                {
                    Console.WriteLine("get A");
                    return _a + 1;
                }
                set
                {
                    Console.WriteLine("set A");
                    _a = value;
                }
            }
    
            public int B
            {
                get
                {
                    Console.WriteLine("get B");
                    return _b + 2;
                }
                set
                {
                    Console.WriteLine("set B");
                    _b = value;
                }
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                var x = new X();
    
                Console.WriteLine("Assign");
                int y = x.B = x.A = 125;
    
                Console.WriteLine("Read");
                Console.WriteLine("y " + y + " x.B " + x.B + " x.A " + x.A);
    
                Console.ReadLine();
            }
        }
    }
