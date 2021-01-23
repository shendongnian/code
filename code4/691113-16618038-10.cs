    <!-- language: lang-cs -->
        using System;
        using System.Runtime.InteropServices;
        namespace Foo {
            class MainClass {
                [DllImport("Foo.so", CallingConvention = CallingConvention.Cdecl)]
                private static extern void hs_init(IntPtr argc, IntPtr argv);
                [DllImport("Foo.so", CallingConvention = CallingConvention.Cdecl)]
                private static extern void hs_exit();
                [DllImport("Foo.so", CallingConvention = CallingConvention.Cdecl)]
                private static extern int foo(string str);
                public static void Main(string[] args) {
                    Console.WriteLine("Initializing runtime...");
                    hs_init(IntPtr.Zero, IntPtr.Zero);
                    try {
                        Console.WriteLine("Calling to Haskell...");
                        int result = foo("C#");
                        Console.WriteLine("Got result: {0}", result);
                    } finally {
                        Console.WriteLine("Exiting runtime...");
                        hs_exit();
                    }
                }
            }
        }
