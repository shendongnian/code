    [Flags]
    public enum SaferLevels : uint
    {
        Disallowed = 0,
        Untrusted = 0x1000,
        Constrained = 0x10000,
        NormalUser = 0x20000,
        FullyTrusted = 0x40000
    }
    [Flags]
    public enum SaferComputeTokenFlags : uint
    {
        None = 0x0,
        NullIfEqual = 0x1,
        CompareOnly = 0x2,
        MakeIntert = 0x4,
        WantFlags = 0x8
    }
    [Flags]
    public enum SaferScopes : uint
    {
        Machine = 1,
        User = 2
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct SECURITY_ATTRIBUTES
    {
        public int nLength;
        public IntPtr lpSecurityDescriptor;
        public int bInheritHandle;
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    struct STARTUPINFO
    {
        public Int32 cb;
        public string lpReserved;
        public string lpDesktop;
        public string lpTitle;
        public Int32 dwX;
        public Int32 dwY;
        public Int32 dwXSize;
        public Int32 dwYSize;
        public Int32 dwXCountChars;
        public Int32 dwYCountChars;
        public Int32 dwFillAttribute;
        public Int32 dwFlags;
        public Int16 wShowWindow;
        public Int16 cbReserved2;
        public IntPtr lpReserved2;
        public IntPtr hStdInput;
        public IntPtr hStdOutput;
        public IntPtr hStdError;
    }
    [StructLayout(LayoutKind.Sequential)]
    internal struct PROCESS_INFORMATION
    {
        public IntPtr hProcess;
        public IntPtr hThread;
        public int dwProcessId;
        public int dwThreadId;
    }
    [DllImport("advapi32", SetLastError = true, CallingConvention = CallingConvention.StdCall)]
    public static extern bool SaferComputeTokenFromLevel(IntPtr LevelHandle, IntPtr InAccessToken, out IntPtr OutAccessToken, int dwFlags, IntPtr lpReserved);
    [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Auto)]
    static extern bool CreateProcessAsUser(
        IntPtr hToken,
        string lpApplicationName,
        string lpCommandLine,
        ref SECURITY_ATTRIBUTES lpProcessAttributes,
        ref SECURITY_ATTRIBUTES lpThreadAttributes,
        bool bInheritHandles,
        uint dwCreationFlags,
        IntPtr lpEnvironment,
        string lpCurrentDirectory,
        ref STARTUPINFO lpStartupInfo,
        out PROCESS_INFORMATION lpProcessInformation); 
    [DllImport("advapi32", SetLastError = true, CallingConvention = CallingConvention.StdCall)]
    public static extern bool SaferCreateLevel(
        SaferScopes dwScopeId,
        SaferLevels dwLevelId,
        int OpenFlags,
        out IntPtr pLevelHandle,
        IntPtr lpReserved);
    [DllImport("advapi32", SetLastError = true, CallingConvention = CallingConvention.StdCall)]
    public static extern bool SaferCloseLevel(
        IntPtr pLevelHandle);
    [DllImport("advapi32", SetLastError = true, CallingConvention = CallingConvention.StdCall)]
    public static extern bool SaferComputeTokenFromLevel(
      IntPtr levelHandle,
      IntPtr inAccessToken,
      out IntPtr outAccessToken,
      SaferComputeTokenFlags dwFlags,
      IntPtr lpReserved
    );
    [DllImport("kernel32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool CloseHandle(IntPtr hObject);
