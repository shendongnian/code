    <!-- language: lang-cs -->
        using System;
        using System.Runtime.InteropServices;
    
        namespace Foo {
            class MainClass {
                [DllImport("Foo.so")]
                private static extern void hs_init(int argc, string[] argv);
    
                [DllImport("Foo.so")]
                private static extern int foo(string str);
    
                public static void Main(string[] args) {
                    Console.WriteLine("Initializing runtime...");
                    hs_init(args.Length, args);
                    Console.WriteLine("Calling to Haskell...");
                    int result = foo("C#");
                    Console.WriteLine("Got result: {0}", result);
                }
            }
        }
