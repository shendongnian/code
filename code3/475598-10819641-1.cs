    public delegate bool WindowEnumCallback(int hwnd, int lparam);
    
    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool EnumWindows(WindowEnumCallback lpEnumFunc, int lParam);
    
    [DllImport("user32.dll")]
    public static extern void GetWindowText(int h, StringBuilder s, int nMaxCount);
    [DllImport("user32.dll")]
    public static extern bool IsWindowVisible(int h);
    
    private List<string> Windows = new List<string>();
    private bool AddWnd(int hwnd, int lparam)
    {
        if (IsWindowVisible(hwnd))
        {
          StringBuilder sb = new StringBuilder(255);
          GetWindowText(hwnd, sb, sb.Capacity);
          Windows.Add(sb.ToString());
          return(true);
        }
    }
    
    private void Form1_Load(object sender, EventArgs e)
    {
        EnumWindows(new WindowEnumCallback(this.AddWnd), 0);
    }
