    [STAThread]
    static void Main()
	{
	Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.SetUnhandledExceptionMode(UnhandledExceptionMode.ThrowException);
			Application.Run(new Form1());
		}
