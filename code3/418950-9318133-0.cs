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
