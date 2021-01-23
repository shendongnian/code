    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        private static readonly ILog log = LogManager.GetLogger(typeof(Program));
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            AppDomain.CurrentDomain.FirstChanceException += FirstChanceHandler;
            Application.Run(new Forms.Main());
        }
        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            log.Info(e.Exception.Message);
        }
        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            log.Info(e);
        }
        static void FirstChanceHandler(object source, FirstChanceExceptionEventArgs e)
        {
            log.Info(e.Exception.Message);
        }
    }
