    static class Program
    {
        static Mutex mutex;
    
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var guid = ((System.Runtime.InteropServices.GuidAttribute)(System.Reflection.Assembly.GetEntryAssembly().GetCustomAttributes(typeof(System.Runtime.InteropServices.GuidAttribute), false).Single())).Value;
            bool alreadyRun;
            mutex = new Mutex(false, "App_Name" + guid.ToString(), out alreadyRun);
            if (!alreadyRun) return;        
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());        }
    }
