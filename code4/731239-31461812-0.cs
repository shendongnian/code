    public static void Main (string[] args)
    {
      using(Init())
      {
        Application.Init ();
        MainWindow win = new MainWindow ();
        win.Show ();
        Application.Run ();      
      }
    }
    
    private static OpenTK.Toolkit Init()
    {
      return Toolkit.Init(new ToolkitOptions
      {
          Backend = PlatformBackend.PreferNative
      });
    }
