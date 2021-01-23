    static void Main(string[] args)
    {      
        AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
        //... do something ...      
    }
        
    static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
    {
          System.Diagnostics.Trace.WriteLine((e.ExceptionObject as Exception).Message, "Unhandled UI Exception");
          // here you can log the exception ...
    }
