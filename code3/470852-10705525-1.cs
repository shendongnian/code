    public class ApiUtils
    {
        [DllImport("user32")]
        public static extern int SetForegroundWindow(IntPtr hwnd);
        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, ShowWindowCommand nCmdShow);
        [DllImport("user32.dll")]
        public static extern int GetForegroundWindow();
        public static void ActiveWindow(IntPtr hwnd)
        {
            if ((IntPtr)GetForegroundWindow() != hwnd)
            {
                ShowWindow(hwnd, ShowWindowCommand.ShowMaximized);
            }
        }
    }
