    using System;
    using System.Diagnostics;
    
    class Program {
        static void Main(string[] args) {
            var prc = Process.Start("notepad.exe");
            prc.WaitForInputIdle();
            foreach (ProcessModule module in prc.Modules) {
                if (string.Compare(module.ModuleName, "user32.dll", true) == 0) {
                    Console.WriteLine("User32 loaded at 0x{0:X16}", (long)module.BaseAddress);
                    break;
                }
            }
            prc.Kill();
            Console.ReadLine();
        }
    }
