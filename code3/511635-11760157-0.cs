    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);
    [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
    static extern int GetWindowTextLength(IntPtr hWnd);
    [DllImport("user32")]
    public static extern int EnumWindows(CallBack x, int y);
    public static void Main()
    {
        CallBack myCallBack = new CallBack(EnumReportApp.Report);
        EnumWindows(myCallBack, 0);
    }
    public static bool Report(int hwnd, int lParam)
    {        
        int length = GetWindowTextLength((IntPtr)hwnd);
        StringBuilder sb = new StringBuilder(length + 1);
        GetWindowText((IntPtr)hwnd, sb, sb.Capacity);
        if (sb.ToString().StartsWith("Order Entry"))
        {
            Console.Write("Window handle is ");
            Console.WriteLine(hwnd);
