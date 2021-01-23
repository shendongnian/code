    using System;
    class Program
    {
        class Foo
        {
            public Foo()
            {
                Console.WriteLine("Building Foo");
            }
            public int Bar
            {
                get
                {
                    Console.WriteLine("Getting Foo.Bar");
                    return 0;
                }
                set
                {
                    Console.WriteLine("Setting Foo.Bar: boom!");
                    throw new Exception();
                }
            }
        }
        static Foo foo2;
        static Foo foo
        {
            get
            {
                Console.WriteLine("Getting foo");
                return foo2;
            }
            set
            {
                Console.WriteLine("Setting foo");
                foo2 = value;
            }
        }
        static void Main(string[] args)
        {
            try
            {
                foo = new Foo { Bar = 100 };
                // Not executed, only to disassemble and check 
                // that it isn't using special instructions!
                foo = new Foo();
                foo.Bar = 200;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: {0}", ex);
            }
            Console.WriteLine("Finished try/catch");
            Console.WriteLine("foo initialized: {0}", foo != null);
        }
    }
