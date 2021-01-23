    [StructLayout( LayoutKind.Sequential, Pack = 1 )]
    internal struct TokPriv1Luid
    {
        public int Count;
        public long Luid;
        public int Attr;
    }
    [DllImport( "kernel32.dll", ExactSpelling = true )]
    internal static extern IntPtr GetCurrentProcess();
    [DllImport( "advapi32.dll", ExactSpelling = true, SetLastError = true )]
    internal static extern bool OpenProcessToken( IntPtr h, int acc, ref IntPtr phtok );
    [DllImport( "advapi32.dll", SetLastError = true )]
    internal static extern bool LookupPrivilegeValue( string host, string name, ref long pluid );
    [DllImport( "advapi32.dll", ExactSpelling = true, SetLastError = true )]
    internal static extern bool AdjustTokenPrivileges( IntPtr htok, bool disall, ref TokPriv1Luid newst, int len, IntPtr prev, IntPtr relen );
    [DllImport( "user32.dll", ExactSpelling = true, SetLastError = true )]
    internal static extern bool ExitWindowsEx( int flg, int rea );
    public const int SE_PRIVILEGE_ENABLED = 0x00000002;
    public const int TOKEN_QUERY = 0x00000008;
    public const int TOKEN_ADJUST_PRIVILEGES = 0x00000020;
    public const string SE_SHUTDOWN_NAME = "SeShutdownPrivilege";
    public const int EWX_LOGOFF = 0x00000000;
    public const int EWX_SHUTDOWN = 0x00000001;
    public const int EWX_REBOOT = 0x00000002;
    public const int EWX_FORCE = 0x00000004;
    public const int EWX_POWEROFF = 0x00000008;
    public const int EWX_FORCEIFHUNG = 0x00000010;
    public static bool DoExitWin( int flg )
    {
        TokPriv1Luid tp;
        var hproc = GetCurrentProcess();
        var htok = IntPtr.Zero;
        OpenProcessToken( hproc, TOKEN_ADJUST_PRIVILEGES | TOKEN_QUERY, ref htok );
        tp.Count = 1;
        tp.Luid = 0;
        tp.Attr = SE_PRIVILEGE_ENABLED;
        LookupPrivilegeValue( null, SE_SHUTDOWN_NAME, ref tp.Luid );
        AdjustTokenPrivileges( htok, false, ref tp, 0, IntPtr.Zero, IntPtr.Zero );
        return ExitWindowsEx( flg, 0 );
    }
