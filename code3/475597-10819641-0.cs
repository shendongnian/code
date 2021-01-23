    public delegate bool WindowEnumCallback(int hwnd, int lparam);
    
    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool EnumWindows(WindowEnumCallback lpEnumFunc, int lParam);
    
    [DllImport("user32.dll")]
    public static extern void GetWindowText(int h, StringBuilder s, int nMaxCount);
    
    private List<string> Windows = new List<string>();
    private void AddWnd(int hwnd, int lparam)
    {
        StringBuilder sb = new StringBuilder(255);
        GetWindowText(hwnd, sb, sb.Capacity);
        Windows.Add(sb.ToString());
    }
    
    private void Form1_Load(object sender, EventArgs e)
    {
        EnumWindows(new WindowEnumCallback(this.AddWnd), 0);
    }
