    // All offset values below have been tested on Windows 7 & 8 only
    // but you can use WinDbg "dt ntdll!_PEB" command and search for ProcessParameters offset to find the truth, depending on the OS version
    public static class ProcessUtilities
    {
        public static string GetCurrentDirectory(int processId)
        {
            return GetProcessParametersString(processId, Environment.Is64BitOperatingSystem ? 0x38 : 0x24);
        }
        public static string GetCurrentDirectory(this Process process)
        {
            if (process == null)
                throw new ArgumentNullException("process");
            return GetCurrentDirectory(process.Id);
        }
        public static string GetCommandLine(int processId)
        {
            return GetProcessParametersString(processId, Environment.Is64BitOperatingSystem ? 0x70 : 0x40);
        }
        public static string GetCommandLine(this Process process)
        {
            if (process == null)
                throw new ArgumentNullException("process");
            return GetCommandLine(process.Id);
        }
        private static string GetProcessParametersString(int processId, int offset)
        {
            IntPtr handle = OpenProcess(PROCESS_QUERY_INFORMATION | PROCESS_VM_READ, false, processId);
            if (handle == IntPtr.Zero)
                throw new Win32Exception(Marshal.GetLastWin32Error());
            int processParametersOffset = Environment.Is64BitOperatingSystem ? 0x20 : 0x10;
            try
            {
                if (Environment.Is64BitOperatingSystem && !Environment.Is64BitProcess) // are we running in WOW?
                {
                    PROCESS_BASIC_INFORMATION_WOW64 pbi = new PROCESS_BASIC_INFORMATION_WOW64();
                    int hr = NtWow64QueryInformationProcess64(handle, 0, ref pbi, Marshal.SizeOf(pbi), IntPtr.Zero);
                    if (hr != 0)
                        throw new Win32Exception(hr);
                    long pp = 0;
                    hr = NtWow64ReadVirtualMemory64(handle, pbi.PebBaseAddress + processParametersOffset, ref pp, Marshal.SizeOf(pp), IntPtr.Zero);
                    if (hr != 0)
                        throw new Win32Exception(hr);
                    UNICODE_STRING_WOW64 us = new UNICODE_STRING_WOW64();
                    hr = NtWow64ReadVirtualMemory64(handle, pp + offset, ref us, Marshal.SizeOf(us), IntPtr.Zero);
                    if (hr != 0)
                        throw new Win32Exception(hr);
                    if ((us.Buffer == 0) || (us.Length == 0))
                        return null;
                    string s = new string('\0', us.Length / 2);
                    hr = NtWow64ReadVirtualMemory64(handle, us.Buffer, s, us.Length, IntPtr.Zero);
                    if (hr != 0)
                        throw new Win32Exception(hr);
                    return s;
                }
                else // we are running with the same bitness as the OS, 32 or 64
                {
                    PROCESS_BASIC_INFORMATION pbi = new PROCESS_BASIC_INFORMATION();
                    int hr = NtQueryInformationProcess(handle, 0, ref pbi, Marshal.SizeOf(pbi), IntPtr.Zero);
                    if (hr != 0)
                        throw new Win32Exception(hr);
                    IntPtr pp = new IntPtr();
                    if (!ReadProcessMemory(handle, pbi.PebBaseAddress + processParametersOffset, ref pp, new IntPtr(Marshal.SizeOf(pp)), IntPtr.Zero))
                        throw new Win32Exception(Marshal.GetLastWin32Error());
                    UNICODE_STRING us = new UNICODE_STRING();
                    if (!ReadProcessMemory(handle, pp + offset, ref us, new IntPtr(Marshal.SizeOf(us)), IntPtr.Zero))
                        throw new Win32Exception(Marshal.GetLastWin32Error());
                    if ((us.Buffer == IntPtr.Zero) || (us.Length == 0))
                        return null;
                    string s = new string('\0', us.Length / 2);
                    if (!ReadProcessMemory(handle, us.Buffer, s, new IntPtr(us.Length), IntPtr.Zero))
                        throw new Win32Exception(Marshal.GetLastWin32Error());
                    return s;
                }
            }
            finally
            {
                CloseHandle(handle);
            }
        }
        private const int PROCESS_QUERY_INFORMATION = 0x400;
        private const int PROCESS_VM_READ = 0x10;
        [StructLayout(LayoutKind.Sequential)]
        private struct PROCESS_BASIC_INFORMATION
        {
            public IntPtr Reserved1;
            public IntPtr PebBaseAddress;
            public IntPtr Reserved2_0;
            public IntPtr Reserved2_1;
            public IntPtr UniqueProcessId;
            public IntPtr Reserved3;
        }
        [StructLayout(LayoutKind.Sequential)]
        private struct UNICODE_STRING
        {
            public short Length;
            public short MaximumLength;
            public IntPtr Buffer;
        }
        // for 32-bit process in a 64-bit OS only
        [StructLayout(LayoutKind.Sequential)]
        private struct PROCESS_BASIC_INFORMATION_WOW64
        {
            public long Reserved1;
            public long PebBaseAddress;
            public long Reserved2_0;
            public long Reserved2_1;
            public long UniqueProcessId;
            public long Reserved3;
        }
        // for 32-bit process in a 64-bit OS only
        [StructLayout(LayoutKind.Sequential)]
        private struct UNICODE_STRING_WOW64
        {
            public short Length;
            public short MaximumLength;
            public long Buffer;
        }
        [DllImport("ntdll.dll")]
        private static extern int NtQueryInformationProcess(IntPtr ProcessHandle, int ProcessInformationClass, ref PROCESS_BASIC_INFORMATION ProcessInformation, int ProcessInformationLength, IntPtr ReturnLength);
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, ref IntPtr lpBuffer, IntPtr dwSize, IntPtr lpNumberOfBytesRead);
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, ref UNICODE_STRING lpBuffer, IntPtr dwSize, IntPtr lpNumberOfBytesRead);
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, [MarshalAs(UnmanagedType.LPWStr)] string lpBuffer, IntPtr dwSize, IntPtr lpNumberOfBytesRead);
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);
        [DllImport("kernel32.dll")]
        private static extern bool CloseHandle(IntPtr hObject);
        // for 32-bit process in a 64-bit OS only
        [DllImport("ntdll.dll")]
        private static extern int NtWow64QueryInformationProcess64(IntPtr ProcessHandle, int ProcessInformationClass, ref PROCESS_BASIC_INFORMATION_WOW64 ProcessInformation, int ProcessInformationLength, IntPtr ReturnLength);
        [DllImport("ntdll.dll")]
        private static extern int NtWow64ReadVirtualMemory64(IntPtr hProcess, long lpBaseAddress, ref long lpBuffer, long dwSize, IntPtr lpNumberOfBytesRead);
        [DllImport("ntdll.dll")]
        private static extern int NtWow64ReadVirtualMemory64(IntPtr hProcess, long lpBaseAddress, ref UNICODE_STRING_WOW64 lpBuffer, long dwSize, IntPtr lpNumberOfBytesRead);
        [DllImport("ntdll.dll")]
        private static extern int NtWow64ReadVirtualMemory64(IntPtr hProcess, long lpBaseAddress, [MarshalAs(UnmanagedType.LPWStr)] string lpBuffer, long dwSize, IntPtr lpNumberOfBytesRead);
    }
