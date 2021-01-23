    using System;
    namespace Demo
    {
        class Demo
        {
            public int Value;
            public Demo(int value)
            {
                Value = value;
            }
        }
        class Program
        {
            private static void test1(Demo demo)
            {
                demo = new Demo(42);
            }
            private static void test2(ref Demo demo)
            {
                demo = new Demo(42);
            }
            private static void Main()
            {
                Demo demo1 = new Demo(0);
                Demo demo2 = demo1; // demo2 references demo1.
                // Calling test1() will NOT change the object referenced by demo1:
                test1(demo1);
                Console.WriteLine(demo1.Value); // Prints 0
                demo2.Value = 1;
                Console.WriteLine(demo1.Value); // Prints 1, indicating that changing demo2 also changed demo1
                // Calling test2() will cause demo1 to reference a DIFFERENT instance of class Demo:
                test2(ref demo1);
                Console.WriteLine(demo1.Value); // Prints 42, indicating that demo1 was changed.
                demo2.Value = 1;
                Console.WriteLine(demo1.Value); // Prints 42, indicating that changing demo2 no longer changes demo1
            }
        }
    }
