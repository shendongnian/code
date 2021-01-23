    using System;
    using System.Diagnostics;
    // To test this program:
    // (1) Start Notepad.
    // (2) Run this program.
    // (3) Close Notepad.
    // (4) This program should print "Notepad exited".
    namespace Demo
    {
        internal class Program
        {
            public static void Main(string[] args)
            {
                foreach (var process in Process.GetProcessesByName("notepad"))
                {
                    Console.WriteLine("Found a Notepad process to attach to.");
                    process.EnableRaisingEvents = true;
                    process.Exited += process_Exited;
                }
                Console.WriteLine("Press ENTER to quit.");
                Console.ReadLine();
            }
            private static void process_Exited(object sender, EventArgs e)
            {
                Console.WriteLine("Notepad exited.");
            }
       }
    }
