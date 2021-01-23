    [DllImport("user32.dll")]
    public static extern long SendMessage(IntPtr Handle, int Msg, int wParam, int lParam);
    public const int WM_CLOSE = 0x0010;
    private static void Main()
    {
        var processes = Process.GetProcessesByName("OtherApp");
        if (processes.Length > 0)
        {
            IntPtr handle = processes[0].MainWindowHandle;
            SendMessage(handle, WM_CLOSE, 0, 0);
        }
    }
