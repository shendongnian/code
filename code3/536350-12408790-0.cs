    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
    
            ConfirmationForm confForm = new ConfirmationForm();
            confForm.ShowDialog();
            Application.Run(new MainForm());
        }
    }
