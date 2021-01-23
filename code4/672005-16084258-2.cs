    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        AppDomain.CurrentDomain.UnhandledException += AppDomain_UnhandledException;
        Application.SetUnhandledExceptionMode(UnhandledExceptionMode.ThrowException);
        Application.Run(new Form1());
    }
    
    static void AppDomain_UnhandledException(Object sender, UnhandledExceptionEventArgs e)
    {
        MessageBox.Show(((Exception)e.ExceptionObject).Message, "AppDomain.UnhandledException");
        Environment.Exit(-1);
    }
