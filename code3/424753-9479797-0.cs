    using System;
    using System.Threading;
    using System.Runtime.InteropServices;
    
    namespace ConsoleApplication2 {
        class Program {
            static void Main(string[] args) {
                ThreadPool.QueueUserWorkItem((o) => {
                    Thread.Sleep(1000);
                    IntPtr stdin = GetStdHandle(StdHandle.Stdin);
                    CloseHandle(stdin);
                });
                Console.ReadLine();
            }
    
            // P/Invoke:
            private enum StdHandle { Stdin = -10, Stdout = -11, Stderr = -12 };
            [DllImport("kernel32.dll")]
            private static extern IntPtr GetStdHandle(StdHandle std);
            [DllImport("kernel32.dll")]
            private static extern bool CloseHandle(IntPtr hdl);
        }
    }
