    class Program
        {
            [DllImport("user32.dll", SetLastError = true)]
            static extern bool SetForegroundWindow(IntPtr hWnd);
    
            private static void BringToFront(string CaptionName)
            {
                foreach (Process p in Process.GetProcesses()
                                             .ToList()
                                             .FindAll(/*Write your rule here*/p => p.MainWindowTitle.Contains(CaptionName)))
                {
                    SetForegroundWindow(p.MainWindowHandle);
                }
            }
    
            static void Main(string[] args)
            {
                BringToFront("Notepad");
            }
        }
