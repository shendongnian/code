        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.ThrowException);
            if (!System.Diagnostics.Debugger.IsAttached) {
                AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            }
            Application.Run(new Form1());
        }
