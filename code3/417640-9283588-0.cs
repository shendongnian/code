    public class MoveToForeground
    {
        [DllImportAttribute("User32.dll")]
        private static extern int FindWindow(string ClassName, string WindowName);
        [DllImport("user32.dll", EntryPoint="SetWindowPos")]
        public static extern IntPtr SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int Y, int cx, int cy, int wFlags);
        const int SWP_NOMOVE = 0x0002;
        const int SWP_NOSIZE = 0x0001;            
        const int SWP_SHOWWINDOW = 0x0040;
        const int SWP_NOACTIVATE = 0x0010;
        public static void DoOnProcess(string processName)
        {
            var process = Process.GetProcessesByName(processName);
            if (process.Length > 0)
            {
                int hWnd = FindWindow(null, process[0].MainWindowTitle.ToString());
                SetWindowPos(new IntPtr(hWnd), 0, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_SHOWWINDOW | SWP_NOACTIVATE);
            }
        }
    }
    MoveToForeground.DoOnProcess("OUTLOOK.EXE");
