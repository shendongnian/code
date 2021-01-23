    public LoadingScreen()
    {
      InitializeComponent();
    }
    public static void ShowLoadingScreen(string usercontrollname)
    {
      // do something with the usercontroll name if desired
      if (_LoadingScreenThread == null)
      {
        _LoadingScreenThread = new Thread(new ThreadStart(DoShowLoadingScreen));
        _LoadingScreenThread.IsBackground = true;
        _LoadingScreenThread.Start();
      }
    }
    public static void CloseLoadingScreen()
    {
      if (_ls.InvokeRequired)
      {
        _ls.Invoke(new MethodInvoker(CloseLoadingScreen));
      }
      else
      {
        Application.ExitThread();
        _ls.Dispose();
        _LoadingScreenThread = null;
      }
    }
    private static void DoShowLoadingScreen()
    {
        _ls = new LoadingScreen();
        _ls.FormBorderStyle = FormBorderStyle.None;
        _ls.MinimizeBox = false;
        _ls.ControlBox = false;
        _ls.MaximizeBox = false;
        _ls.TopMost = true;
        _ls.StartPosition = FormStartPosition.CenterScreen;
      Application.Run(_ls);
    }
