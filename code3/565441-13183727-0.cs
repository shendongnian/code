    static class Program
    {
        public static bool KeepRunning { get; set; }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            KeepRunning = true;
            while(KeepRunning)
            {
                KeepRunning = false;
                Application.Run(new Form1());
            }
        }
    }
