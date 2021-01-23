    using System;
    
    class Program {
        static void Main(string[] args) {
            var obj = new Foo();
            // There are 3 generations, could have used GC.MaxGeneration
            for (int ix = 0; ix < 3; ++ix) {
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            Console.ReadLine();
        }
    }
    
    class Foo {
        int attempt = 0;
        ~Foo() {
            // Don't try to do this over and over again, rough at program exit
            if (attempt++ < 3) {
                GC.ReRegisterForFinalize(this);
                Console.WriteLine(GC.GetGeneration(this));
            }
        }
    }
