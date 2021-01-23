    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace Exercise_01
    {
        public struct Coords
        {
            public int X;
            public int Y;
            public override string ToString() => $"({X}, {Y})";
        }
        class Program
        {
            static unsafe void Main(string[] args)
            {
                int n = 0;
                SumCallByRefPointer(1, 2, &n);
                Console.Clear();
                Console.WriteLine("call by refrence {0}",n);
              
                n = 0;
                SumCallByValue(3, 4, n);
                Console.WriteLine("call by Value {0}", n);
                n = 0;
                SumCallByRef(5, 6, ref n);
                Console.WriteLine("call by refrence {0}", n);
 
                Pointer();
                Console.ReadLine();
            } 
            private static unsafe void SumCallByRefPointer(int a, int b, int* c)
            {
                *c = a + b;
            }
            private static unsafe void SumCallByValue(int a, int b, int c)
            {
                c = a + b;
            } 
            private static unsafe void SumCallByRef(int a, int b, ref int c)
            {
                c = a + b;
            }
            public static void Pointer()
            {
                unsafe
                {
                    Coords coords;
                    Coords* p = &coords;
                    p->X = 3;
                    p->Y = 4;
                    Console.WriteLine(p->ToString());  // output: (3, 4)
                }
            }
        }
    }
