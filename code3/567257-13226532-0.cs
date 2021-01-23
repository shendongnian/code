    static class Program
    {
        public static MainForm mainForm = new MainForm();
        public static LoginForm loginForm = new LoginForm();
        [STAThread]
        static void Main()
        {
            mainForm.Hide();
            loginForm.Hide();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(loginForm);
        }
        public static void Login()
        {
            loginForm.Hide();
            mainForm.Show();
            // probably do more here
        }
        public static void Logout()
        {
            if (MessageBox.Show("Do you really want to log out?", "Alert", MessageBoxButtons.YesNo).Equals(DialogResult.Yes)))
            {
                mainForm.Hide();
                loginForm.Show();
                // probably do more here
            } 
        }
    }
