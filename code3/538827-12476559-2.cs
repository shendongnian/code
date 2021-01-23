    using System;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            [DllImport("user32.dll")]
            static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
    
            static void Main()
            {
                var processes = Process.GetProcessesByName("iexplore");
    
                foreach (var process in processes)
                {
                    ShowWindow(process.MainWindowHandle, 2);
                }
            }
        }
    }
