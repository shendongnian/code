    using System;
    
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Working on it...");
            //...
            Console.WriteLine("Done");
            PressAnyKey();
        }
        private static void PressAnyKey() {
            if (GetConsoleProcessList(new int[2], 2) <= 1) {
                Console.Write("Press any key to continue");
                Console.ReadKey();
            }
        }
        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        private static extern int GetConsoleProcessList(int[] buffer, int size);
    }
