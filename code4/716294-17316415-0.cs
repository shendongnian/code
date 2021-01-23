    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            TheForm = new Form1();
            Application.Run(TheForm);
        }
        private static Form1 TheForm { get; set; }
        public static void bridge()
        {
            TheForm.Click();
        }
    }
