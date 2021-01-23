    public static class WinApi {
        public const int PROCESS_ALL_ACCESS = /* whatever the value is */;
        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess,
            bool bInheritHandle, int dwProcessId);
    }
