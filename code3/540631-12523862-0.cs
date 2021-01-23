    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                IFoo foo = new Foo();
                Console.WriteLine("Will return 10: {0}", foo.Bar());
    
                foo[10] = 20;
                Console.WriteLine("Will return 20: {0}", foo[10]);
            }
        }
    
        interface IFoo
        {
            int Bar();
            int this[int i] { get; set; }
        }
    
        class Foo : IFoo
        {
            private int[] array = new int[100];
            public int Bar()
            {
                return 10;
            }
    
            public int this[int i]
            {
                get
                {
                    if (i >= 100)
                    {
                        throw new IndexOutOfRangeException("Maximum range is 100");
                    }
                    return array[i];
                }
                set
                {
                    array[i] = value;
                }
            }
        }
    }
