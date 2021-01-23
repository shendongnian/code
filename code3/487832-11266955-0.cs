    public static class ProcessExtensions
    {
        public enum SECURITY_IMPERSONATION_LEVEL
        {
            SecurityAnonymous,
            SecurityIdentification,
            SecurityImpersonation,
            SecurityDelegation
        }
        [StructLayout(LayoutKind.Sequential)]
        public class SECURITY_ATTRIBUTES
        {
            public int nLength;
            public IntPtr lpSecurityDescriptor;
            public int bInheritHandle;
        }
        public enum TOKEN_TYPE
        {
            TokenPrimary = 1,
            TokenImpersonation
        }
        [Flags]
        public enum CREATE_PROCESS_FLAGS : uint
        {
            NONE = 0x00000000,
            DEBUG_PROCESS = 0x00000001,
            DEBUG_ONLY_THIS_PROCESS = 0x00000002,
            CREATE_SUSPENDED = 0x00000004,
            DETACHED_PROCESS = 0x00000008,
            CREATE_NEW_CONSOLE = 0x00000010,
            NORMAL_PRIORITY_CLASS = 0x00000020,
            IDLE_PRIORITY_CLASS = 0x00000040,
            HIGH_PRIORITY_CLASS = 0x00000080,
            REALTIME_PRIORITY_CLASS = 0x00000100,
            CREATE_NEW_PROCESS_GROUP = 0x00000200,
            CREATE_UNICODE_ENVIRONMENT = 0x00000400,
            CREATE_SEPARATE_WOW_VDM = 0x00000800,
            CREATE_SHARED_WOW_VDM = 0x00001000,
            CREATE_FORCEDOS = 0x00002000,
            BELOW_NORMAL_PRIORITY_CLASS = 0x00004000,
            ABOVE_NORMAL_PRIORITY_CLASS = 0x00008000,
            INHERIT_PARENT_AFFINITY = 0x00010000,
            INHERIT_CALLER_PRIORITY = 0x00020000,
            CREATE_PROTECTED_PROCESS = 0x00040000,
            EXTENDED_STARTUPINFO_PRESENT = 0x00080000,
            PROCESS_MODE_BACKGROUND_BEGIN = 0x00100000,
            PROCESS_MODE_BACKGROUND_END = 0x00200000,
            CREATE_BREAKAWAY_FROM_JOB = 0x01000000,
            CREATE_PRESERVE_CODE_AUTHZ_LEVEL = 0x02000000,
            CREATE_DEFAULT_ERROR_MODE = 0x04000000,
            CREATE_NO_WINDOW = 0x08000000,
            PROFILE_USER = 0x10000000,
            PROFILE_KERNEL = 0x20000000,
            PROFILE_SERVER = 0x40000000,
            CREATE_IGNORE_SYSTEM_DEFAULT = 0x80000000,
        }
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct STARTUPINFO
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
        public struct PROCESS_INFORMATION
        {
            public IntPtr hProcess;
            public IntPtr hThread;
            public int dwProcessId;
            public int dwThreadId;
        }
        public class Kernel32
        {
            [DllImport("kernel32.dll", EntryPoint = "WTSGetActiveConsoleSessionId")]
            public static extern uint WTSGetActiveConsoleSessionId();
            [DllImport("kernel32.dll", SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool CloseHandle(IntPtr hObject);
        }
        public class WtsApi32
        {
            [DllImport("Wtsapi32.dll", EntryPoint = "WTSQueryUserToken")]
            public static extern bool WTSQueryUserToken(ulong sessionId, out IntPtr phToken);
        }
        public class AdvApi32
        {
            public const uint MAXIMUM_ALLOWED = 0x2000000;
            [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            public extern static bool DuplicateTokenEx
            (
                IntPtr hExistingToken,
                uint dwDesiredAccess,
                SECURITY_ATTRIBUTES lpTokenAttributes,
                SECURITY_IMPERSONATION_LEVEL ImpersonationLevel,
                TOKEN_TYPE TokenType,
                out IntPtr phNewToken
            );
            [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            public static extern bool CreateProcessAsUser
            (
                IntPtr hToken,
                string lpApplicationName,
                string lpCommandLine,
                SECURITY_ATTRIBUTES lpProcessAttributes,
                SECURITY_ATTRIBUTES lpThreadAttributes,
                bool bInheritHandles,
                CREATE_PROCESS_FLAGS dwCreationFlags,
                IntPtr lpEnvironment,
                string lpCurrentDirectory,
                ref STARTUPINFO lpStartupInfo,
                out PROCESS_INFORMATION lpProcessInformation
            );
        }
        public class UserEnv
        {
            [DllImport("userenv.dll", SetLastError = true)]
            public static extern bool CreateEnvironmentBlock(out IntPtr lpEnvironment, IntPtr hToken, bool bInherit);
            [DllImport("userenv.dll", SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool DestroyEnvironmentBlock(IntPtr lpEnvironment);
        }
        public static void StartAsActiveUser(this Process process)
        {
            // Sanity check.
            if (process.StartInfo == null)
            {
                throw new InvalidOperationException("The StartInfo property must be defined");
            }
            if (string.IsNullOrEmpty(process.StartInfo.FileName))
            {
                throw new InvalidOperationException("The StartInfo.FileName property must be defined");
            }
            // Retrieve the active session ID and its related user token.
            var sessionId = Kernel32.WTSGetActiveConsoleSessionId();
            var userTokenPtr = new IntPtr();
            if (!WtsApi32.WTSQueryUserToken(sessionId, out userTokenPtr))
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }
            // Duplicate the user token so that it can be used to create a process.
            var duplicateUserTokenPtr = new IntPtr();
            if (!AdvApi32.DuplicateTokenEx(userTokenPtr, AdvApi32.MAXIMUM_ALLOWED, null, SECURITY_IMPERSONATION_LEVEL.SecurityIdentification, TOKEN_TYPE.TokenPrimary, out duplicateUserTokenPtr))
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }
            // Create an environment block for the interactive process.
            var environmentPtr = new IntPtr();
            if (!UserEnv.CreateEnvironmentBlock(out environmentPtr, duplicateUserTokenPtr, false))
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }
            // Create the process under the target user’s context.
            var processFlags = CREATE_PROCESS_FLAGS.NORMAL_PRIORITY_CLASS | CREATE_PROCESS_FLAGS.CREATE_NEW_CONSOLE | CREATE_PROCESS_FLAGS.CREATE_UNICODE_ENVIRONMENT;
            var processInfo = new PROCESS_INFORMATION();
            var startupInfo = new STARTUPINFO();
            startupInfo.cb = Marshal.SizeOf(startupInfo);
            if (!AdvApi32.CreateProcessAsUser
            (
                duplicateUserTokenPtr, 
                process.StartInfo.FileName, 
                process.StartInfo.Arguments, 
                null, 
                null, 
                false, 
                processFlags, 
                environmentPtr, 
                null, 
                ref startupInfo, 
                out processInfo
            ))
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }
            // Free used resources.
            Kernel32.CloseHandle(processInfo.hProcess);
            Kernel32.CloseHandle(processInfo.hThread);
            if (userTokenPtr != null)
            {
                Kernel32.CloseHandle(userTokenPtr);
            }
            if (duplicateUserTokenPtr != null)
            {
                Kernel32.CloseHandle(duplicateUserTokenPtr);
            }
            if (environmentPtr != null)
            {
                UserEnv.DestroyEnvironmentBlock(environmentPtr);
            }
        }
    }
