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
            Application.Run(new LoginForm());
            if (LoginForm._loginSuccess)
            {
                var m = new MainForm();
                Application.Run(m);
            }
            else
                Application.Exit();
        }
        public static bool UserLogin() //Add some parameter
        {
            //You Logic here
            LoginForm._loginSuccess = true;
            return LoginForm._loginSuccess;
        }
    }
