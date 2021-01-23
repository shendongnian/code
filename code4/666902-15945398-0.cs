    [DllImport("kernel32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool AllocConsole();
    [DllImport("kernel32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool FreeConsole();
    static void Main(string[] args)
    {
        Process p = new Process();
        ProcessStartInfo info = new ProcessStartInfo("cmd.exe");
        info.RedirectStandardInput = true;
        info.UseShellExecute = false;
        info.CreateNoWindow = false;
    
        p.StartInfo = info;
        AllocConsole();
        p.Start();
        FreeConsole();
        
    
        using (StreamWriter sw = p.StandardInput)
        {
            if (sw.BaseStream.CanWrite)
            {
                 sw.WriteLine("dir");
                 sw.WriteLine("ipconfig");
            }
        }
    }
