    static class Program
    {
        static Mutex mutex;
    
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool alreadyRun;
            mutex = new Mutex(false, "App_Name" +Assembly.GetExecutingAssembly().GetType().GUID.ToString(), out alreadyRun);
            if (!alreadyRun) return;        
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
