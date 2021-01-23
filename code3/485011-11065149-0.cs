    static void Main(string[] args)
    {
        Process[] procs = Process.GetProcesses();
        foreach (Process proc in procs)
        {
            if (proc.ProcessName == "notepad")
            {
                var placement = GetPlacement(proc.MainWindowHandle);
                MessageBox.Show(placement.showCmd.ToString());
            }
        }
    }
    private static WINDOWPLACEMENT GetPlacement(IntPtr hwnd)
    {
        WINDOWPLACEMENT placement = new WINDOWPLACEMENT();
        placement.length = Marshal.SizeOf(placement);
        GetWindowPlacement(hwnd, ref placement);
        return placement;
    }
    [DllImport("user32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    internal static extern bool GetWindowPlacement(
        IntPtr hWnd, ref WINDOWPLACEMENT lpwndpl);
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    internal struct WINDOWPLACEMENT
    {
        public int length;
        public int flags;
        public ShowWindowCommands showCmd;
        public System.Drawing.Point ptMinPosition;
        public System.Drawing.Point ptMaxPosition;
        public System.Drawing.Rectangle rcNormalPosition;
    }
    internal enum ShowWindowCommands : int
    {
        Hide = 0,
        Normal = 1,
        Minimized = 2,
        Maximized = 3,
    }
