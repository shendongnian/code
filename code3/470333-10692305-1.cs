    static void Main(string[] args)
    {
      AppDomain.UnhandledException += WriteUnhandledExceptionToFile;
    
      // rest of program
    }
    
    static void WriteUnhandledExceptionToFile(object sender, UnhandledExceptionEventArgs args)
    {
       // write to where ever you can get it.
       string path = Path.Combine(Environment.CurrentDirectory, "UnhandledException.txt");
       File.WriteAllText(path, args.ExceptionObject.ToString()); // will print message and full stack trace.
    }
