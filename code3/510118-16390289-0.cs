    static class Program
    {
        private static bool doNotExit = true;
        private static FormMain fm;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            while(doNotExit)
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo(Properties.Settings.Default.language);//
                System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo(Properties.Settings.Default.language);//
                doNotExit = false;
                fm = new FormMain();
                fm.lanugageChangedEvent += new EventHandler(main_LanugageChangedEvent);
                Application.Run(fm);
            }
        }
        static void main_LanugageChangedEvent(object sender, EventArgs e)
        {  
            doNotExit = true;
            fm.Close();   
        }
    }
