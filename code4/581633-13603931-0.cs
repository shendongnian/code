    using System;
    namespace ConsoleApplication1
    {
        class Program
        {
            public static int I = 0;
            static Func<string> del = new Func<string>(() => {
                return I.ToString();
            });
            static void Main(string[] args)
            {
                I = 10;
                Console.WriteLine("{0}", del());
            }
        }
    }
