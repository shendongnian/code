    static class Program
    {
        public static FrmMain MainForm;// add this line
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainForm = new FrmMain();// add this line
            Application.Run(MainForm);
        }
    }
