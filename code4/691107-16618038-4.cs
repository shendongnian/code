    <!-- language: lang-cs -->
        using System;
        using System.Runtime.InteropServices;
    
        namespace Foo {
            class MainClass {
                [DllImport("Foo.so")]
                private static extern unsafe void hs_init(int *argc, char**[] argv);
    
                [DllImport("Foo.so")]
                private static extern int foo(string str);
    
                public static void Main(string[] args) {
                    Console.WriteLine("Initializing runtime...");
                    unsafe {
                        // Passing command-line arguments is more difficult, as the
                        // RTS will try to parse its own +RTS ... -RTS arguments and
                        // remove them from the argument list.
                        hs_init(null, null);
                    }
    
                    Console.WriteLine("Calling to Haskell...");
                    int result = foo("C#");
                    Console.WriteLine("Got result: {0}", result);
                }
            }
        }
