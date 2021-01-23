    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Runtime.InteropServices;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            [DllImport("user32.dll")]
            static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
    
            static void Main()
            {
                var processList = Process.GetProcesses();
    
                foreach (var process in processList.Where(process => process.MainWindowTitle.ToUpper().Contains("INTERNET EXPLORER")))
                {
                    ShowWindow(process.MainWindowHandle, 2);
                }
            }
        }
    }
