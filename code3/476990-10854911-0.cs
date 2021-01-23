    [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
    private static extern System.IntPtr GetCommandLine();
    static void Main(string[] args)
    {
      System.IntPtr ptr = GetCommandLine();
      string commandLine = Marshal.PtrToStringAuto(ptr); 
      Console.Read();
      Process.Start(commandLine);
    }
