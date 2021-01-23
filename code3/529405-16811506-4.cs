    private const int SW_SHOW = 5;
    private const uint SEE_MASK_INVOKEIDLIST = 12;
    [DllImport("shell32.dll", CharSet = CharSet.Auto)]
    static extern bool ShellExecuteEx(ref SHELLEXECUTEINFO lpExecInfo);
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct SHELLEXECUTEINFO
    {
         public int cbSize;
         public uint fMask;
         public IntPtr hwnd;
         [MarshalAs(UnmanagedType.LPTStr)]
         public string lpVerb;
         [MarshalAs(UnmanagedType.LPTStr)]
         public string lpFile;
         [MarshalAs(UnmanagedType.LPTStr)]
         public string lpParameters;
         [MarshalAs(UnmanagedType.LPTStr)]
         public string lpDirectory;
         public int nShow;
         public IntPtr hInstApp;
         public IntPtr lpIDList;
         [MarshalAs(UnmanagedType.LPTStr)]
         public string lpClass;
         public IntPtr hkeyClass;
         public uint dwHotKey;
         public IntPtr hIcon;
         public IntPtr hProcess;
  }
