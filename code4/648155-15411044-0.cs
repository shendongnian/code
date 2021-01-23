    [DllImport("kernel32.dll")]
    public static extern IntPtr OpenProcess(uint dwDesiredAccess, bool bInheritHandle, int dwProcessId);
    
    [DllImport("kernel32.dll")]
    public static extern bool ReadProcessMemory(IntPtr hProcess, int lpBaseAddress, ref byte[] buffer, int size, ref int lpNumberOfBytesRead);
    
    [DllImport("kernel32.dll")]
    public static extern bool WriteProcessMemory(IntPtr hProcess, int lpBaseAddress, ref byte[] buffer, int size, ref int lpNumberOfBytesWritten);
