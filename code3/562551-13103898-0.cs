    using System;
    
    class Program {
        static void Main(string[] args) {
            var obj = new Foo();
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
            if (attempt++ < 3) {
                GC.ReRegisterForFinalize(this);
                Console.WriteLine(GC.GetGeneration(this));
            }
        }
    }
