    [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
    private static extern System.IntPtr GetCommandLine();
    static void Main(string[] args)
    {
      System.IntPtr ptr = GetCommandLine();
      string commandLine = Marshal.PtrToStringAuto(ptr); 
      string arguments = commandLine.Substring(commandLine.IndexOf("\"", 1) + 2);
      Console.WriteLine(arguments);
      Process.Start(Assembly.GetEntryAssembly().Location, arguments);
    }
