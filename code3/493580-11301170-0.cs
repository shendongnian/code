    using System;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using System.Reflection;
    
    class Program
    {
        [DllImport("kernel32", SetLastError = true)]
        static extern bool AllocConsole();
    
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool AttachConsole(uint dwProcessId);
    
        const uint ATTACH_PARENT_PROCESS = 0x0ffffffff;
    
    
        [STAThread]
        static void Main(string[] args)
        {
            if (!AttachConsole(ATTACH_PARENT_PROCESS))
            {
                AllocConsole(); 
            }
            Console.WriteLine("This is process {0}, press a key to restart within the same console...", Process.GetCurrentProcess().Id);
            Console.ReadKey(true);
    
            // reboot application
            var process = Process.Start(Assembly.GetExecutingAssembly().Location);
    
            // wait till the new instance is ready, then exit
            process.WaitForInputIdle();
        }
    }
