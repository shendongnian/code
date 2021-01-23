    static class Program
    {
        public static FrmMain MainForm;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainForm = new FrmMain();
            Application.Run(MainForm);
        }
    }
