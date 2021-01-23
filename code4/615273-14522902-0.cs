    [DllImport("user32.dll", EntryPoint="FindWindow", SetLastError = true)]
    static extern IntPtr FindWindowByCaption(IntPtr ZeroOnly, string lpWindowName);
    [DllImport("user32.Dll")]
    static extern int PostMessage(IntPtr hWnd, UInt32 msg, int wParam, int lParam);
    private const UInt32 WM_CLOSE = 0x0010;
    public void ShowAutoClosingMessageBox(string message, string caption)
    {
        var timer = new System.Timers.Timer(5000) { AutoReset = false };
        timer.Elapsed += delegate
        {
            IntPtr hWnd = FindWindowByCaption(IntPtr.Zero, caption);
            if (hWnd.ToInt32() != 0) PostMessage(hWnd, WM_CLOSE, 0, 0);
        };
        timer.Enabled = true;
        MessageBox.Show(message, caption);
    }
