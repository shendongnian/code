[DllImport("kernel32.dll")]
        private static extern IntPtr OpenProcess(uint dwDesiredAccess, bool bInheritHandle, uint dwProcessId);
        [DllImport("advapi32", SetLastError = true), SuppressUnmanagedCodeSecurityAttribute]
        private static extern int OpenProcessToken(System.IntPtr ProcessHandle, int DesiredAccess, ref IntPtr TokenHandle);
        [DllImport("kernel32", SetLastError = true), SuppressUnmanagedCodeSecurityAttribute]
        private static extern bool CloseHandle(IntPtr handle);
        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool DuplicateTokenEx(IntPtr ExistingTokenHandle, uint dwDesiredAccess, IntPtr lpThreadAttributes, int TokenType, int ImpersonationLevel, ref IntPtr DuplicateTokenHandle);
        [DllImport("advapi32.dll", EntryPoint = "DuplicateTokenEx")]
        extern static Boolean DuplicateTokenEx(IntPtr ExistingTokenHandle, UInt32 dwDesiredAccess, ref SECURITY_ATTRIBUTES lpThreadAttributes, Int32 TokenType, Int32 ImpersonationLevel, ref IntPtr DuplicateTokenHandle);
        [DllImport("advapi32.dll", EntryPoint = "CreateProcessAsUser", SetLastError = true, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        private extern static bool CreateProcessAsUser(IntPtr hToken, String lpApplicationName, String lpCommandLine, ref SECURITY_ATTRIBUTES lpProcessAttributes, ref SECURITY_ATTRIBUTES lpThreadAttributes, bool bInheritHandle, int dwCreationFlags, IntPtr lpEnvironment, String lpCurrentDirectory, ref STARTUPINFO lpStartupInfo, out PROCESS_INFORMATION lpProcessInformation);
        #region Win32 Constants
        private const int NORMAL_PRIORITY_CLASS = 0x00000020;
        private const int CREATE_UNICODE_ENVIRONMENT = 0x00000400;
        private const int CREATE_NO_WINDOW = 0x08000000;
        private const int CREATE_NEW_CONSOLE = 0x00000010;
        private const uint INVALID_SESSION_ID = 0xFFFFFFFF;
        private static readonly IntPtr WTS_CURRENT_SERVER_HANDLE = IntPtr.Zero;
        private const int TOKEN_DUPLICATE = 2;
        private const int TOKEN_QUERY = 0X00000008;
        private const int TOKEN_IMPERSONATE = 0X00000004;
        private const uint MAXIMUM_ALLOWED = 0x2000000;
        private const uint PROCESS_QUERY_LIMITED_INFORMATION = 0x1000;
        private const uint PROCESS_QUERY_INFORMATION = 0x0400;
        #endregion
        #region Win32 Structs
        private enum SW
        {
            SW_HIDE = 0,
            SW_SHOWNORMAL = 1,
            SW_NORMAL = 1,
            SW_SHOWMINIMIZED = 2,
            SW_SHOWMAXIMIZED = 3,
            SW_MAXIMIZE = 3,
            SW_SHOWNOACTIVATE = 4,
            SW_SHOW = 5,
            SW_MINIMIZE = 6,
            SW_SHOWMINNOACTIVE = 7,
            SW_SHOWNA = 8,
            SW_RESTORE = 9,
            SW_SHOWDEFAULT = 10,
            SW_MAX = 10
        }
        private enum WTS_CONNECTSTATE_CLASS
        {
            WTSActive,
            WTSConnected,
            WTSConnectQuery,
            WTSShadow,
            WTSDisconnected,
            WTSIdle,
            WTSListen,
            WTSReset,
            WTSDown,
            WTSInit
        }
        [StructLayout(LayoutKind.Sequential)]
        private struct PROCESS_INFORMATION
        {
            public IntPtr hProcess;
            public IntPtr hThread;
            public uint dwProcessId;
            public uint dwThreadId;
        }
        private enum SECURITY_IMPERSONATION_LEVEL
        {
            SecurityAnonymous = 0,
            SecurityIdentification = 1,
            SecurityImpersonation = 2,
            SecurityDelegation = 3,
        }
        [StructLayout(LayoutKind.Sequential)]
        private struct STARTUPINFO
        {
            public int cb;
            public String lpReserved;
            public String lpDesktop;
            public String lpTitle;
            public uint dwX;
            public uint dwY;
            public uint dwXSize;
            public uint dwYSize;
            public uint dwXCountChars;
            public uint dwYCountChars;
            public uint dwFillAttribute;
            public uint dwFlags;
            public short wShowWindow;
            public short cbReserved2;
            public IntPtr lpReserved2;
            public IntPtr hStdInput;
            public IntPtr hStdOutput;
            public IntPtr hStdError;
        }
        private enum TOKEN_TYPE
        {
            TokenPrimary = 1,
            TokenImpersonation = 2
        }
        [StructLayout(LayoutKind.Sequential)]
        private struct WTS_SESSION_INFO
        {
            public readonly UInt32 SessionID;
            [MarshalAs(UnmanagedType.LPStr)]
            public readonly String pWinStationName;
            public readonly WTS_CONNECTSTATE_CLASS State;
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct SECURITY_ATTRIBUTES
        {
            public int Length;
            public IntPtr lpSecurityDescriptor;
            public bool bInheritHandle;
        }
You can then run functionality which would be similar to mine as follows:
       public string Get(string YOURSCRIPT)
        {
            string command = "C:\\Windows\\System32\\WindowsPowerShell\\v1.0\\powershell.exe -File " + YOURSCRIPT;
            bool isSuccessful = false;
            int targetSessionId = 1;
            uint targetWinlogonProcessId = 0;
            IntPtr hToken = IntPtr.Zero, hTokenDup = IntPtr.Zero;
            var procInfo = new PROCESS_INFORMATION();
            Process[] processes = Process.GetProcessesByName("winlogon");
            foreach (Process p in processes)
            {
                if ((uint)p.SessionId == targetSessionId)
                {
                    targetWinlogonProcessId = (uint)p.Id;
                }
            }
            IntPtr hProcess = OpenProcess(MAXIMUM_ALLOWED, false, targetWinlogonProcessId);
            if (OpenProcessToken(hProcess, TOKEN_DUPLICATE, ref hToken) != 0)
            {
                SECURITY_ATTRIBUTES sa = new SECURITY_ATTRIBUTES();
                sa.Length = Marshal.SizeOf(sa);
                if (DuplicateTokenEx(hToken, MAXIMUM_ALLOWED, ref sa, (int)SECURITY_IMPERSONATION_LEVEL.SecurityIdentification, (int)TOKEN_TYPE.TokenPrimary, ref hTokenDup))
                {
                    STARTUPINFO si = new STARTUPINFO();
                    si.cb = (int)Marshal.SizeOf(si);
                    // interactive window station parameter; basically this indicates 
                    // that the process created can display a GUI on the desktop
                    si.lpDesktop = "winsta0\\default";
                    // flags that specify the priority and creation method of the process
                    int dwCreationFlags = NORMAL_PRIORITY_CLASS | CREATE_NEW_CONSOLE;
                    // create a new process in the current User's logon session
                    if (CreateProcessAsUser(hTokenDup,  // client's access token
                                                    null,             // file to execute
                                                    command,          // command line
                                                    ref sa,           // pointer to process SECURITY_ATTRIBUTES
                                                    ref sa,           // pointer to thread SECURITY_ATTRIBUTES
                                                    false,            // handles are not inheritable
                                                    dwCreationFlags,  // creation flags
                                                    IntPtr.Zero,      // pointer to new environment block 
                                                    null,             // name of current directory 
                                                    ref si,           // pointer to STARTUPINFO structure
                                                    out procInfo      // receives information about new process
                                                    ))
                    {
                        isSuccessful = true;
                    }
                    else
                    {
                        int error = Marshal.GetLastWin32Error();
                        int hr = Marshal.GetHRForLastWin32Error();
                    }
                }
                else
                {
                    CloseHandle(hProcess);
                    CloseHandle(hToken);
                }                
            }
            else
                CloseHandle(hProcess);
            return isSuccessful.ToString();
        }
    
