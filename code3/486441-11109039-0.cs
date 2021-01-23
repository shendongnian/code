        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.Automatic);
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
        }
        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            EventLog eLog = new EventLog("SomeLog", ".", "YourApp");
            eLog.WriteEntry(UnrollException(e.Exception), EventLogEntryType.Error);
        }
        static string UnrollException(Exception ex)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(ex.Message);
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
                sb.Append(Environment.NewLine);
                sb.Append(ex.Message);
            }
            return sb.ToString();
        }
