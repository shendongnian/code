    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        ETKSession.DebugMode = false;
        Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
        Application.Run(new frmLogin());
    }
        
    static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
    {
        AErrorLogging.Log(ex); //This is a tested error log writer of mine which usually worked.
        if (ETKSession.DebugMode) throw new Exception(ex.Message, ex);
    }
