      try
      {
        Assembly asm;
        string path;
        path = Path.Combine(
          Directory.GetCurrentDirectory(),
          "CefSharp.Core.dll");
        asm = Assembly.LoadFrom(path);
        path = Path.Combine(
          Directory.GetCurrentDirectory(),
          "CefSharp.OffScreen.dll");
        asm = Assembly.LoadFrom(path);
      }
      catch (Exception exception)
      {
        System.Diagnostics.Trace.WriteLine(exception.Message + " @ " + exception.StackTrace);
      }
