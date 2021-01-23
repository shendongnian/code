    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern bool SetSystemTime(ref SYSTEMTIME lpSystemTime);
    ...
    if (!SetSystemTime(ref sysTime)) {
       throw new System.ComponentModel.Win32Exception();
    }
