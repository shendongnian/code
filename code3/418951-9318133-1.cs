    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private delegate bool EnumThreadWindowsProc(IntPtr handle, int param);
    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool EnumThreadWindows(uint threadId, 
        EnumThreadWindowsProc callback, int param);
    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool IsWindowVisible(IntPtr handle);
    [DllImport("user32.dll", CharSet = CharSet.Unicode)]
    static extern int GetWindowText(
        IntPtr handle, 
        [MarshalAs(UnmanagedType.LPWStr)] StringBuilder caption,
        int count);
    [DllImport("user32.dll", CharSet = CharSet.Unicode)]
    static extern int GetWindowTextLength(IntPtr handle);
    static void Main(string[] args)
    {
        var callback = new EnumThreadWindowsProc(Program.ThreadWindows);
        foreach (var proc in Process.GetProcesses())
        {
            foreach (ProcessThread thread in proc.Threads)
            {
                Program.EnumThreadWindows((uint)thread.Id, callback, 0);
            }
        }
        Console.ReadLine();
    }
    private static bool ThreadWindows(IntPtr handle, int param)
    {           
        if (Program.IsWindowVisible(handle))
        {
            var length = Program.GetWindowTextLength(handle);
            var caption = new StringBuilder(length + 1);
            Program.GetWindowText(handle, caption, caption.Capacity);
            Console.WriteLine("Got a visible window: {0}", caption);
        }
        return true;
    }
