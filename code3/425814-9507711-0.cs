    // C# 2.0
    static void Main(string[] args)
    {
      AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(
        delegate(object sender, UnhandledExceptionEventArgs e) {
          if (e.IsTerminating) {
            object o = e.ExceptionObject;
            Debug.WriteLine(o.ToString());
          }
        }
      );
    
      // rest of your Main code
    }
