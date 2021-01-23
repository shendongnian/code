        [STAThread]
        static void Main() {
            AppDomain.CurrentDomain.UnhandledException += AllUnhandledExceptions;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.ThrowException);
            Application.Run(new Form1());
        }
        private static void AllUnhandledExceptions(object sender, UnhandledExceptionEventArgs e) {
            var ex = (Exception)e.ExceptionObject;
            // Display or log ex.ToString()
            //...
            Environment.Exit(System.Runtime.InteropServices.Marshal.GetHRForException(ex));
        }
