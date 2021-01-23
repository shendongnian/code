    static class Program
    {
        public static ApplicationContext Context { get; set; }
    
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
    
            Context = new ApplicationContext(new LoginForm());
            // pass Context instead of just new LoginForm()
            Application.Run(Context);
        }
    }
