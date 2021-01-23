    static class Program
    {
        private static EventHandler idleTemp;
        private static SplashFrm splash;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            splash = new SplashFrm();
            splash.Show();
            idleTemp = new EventHandler(Application_Idle);
            Application.Idle += idleTemp;
            Application.Run(new AMBR());
        }
        static void Application_Idle(object sender, EventArgs e)
        {
            splash.Close();
            Application.Idle -= idleTemp;
            idleTemp = null;
            splash = null;
        }
    }
