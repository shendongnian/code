        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            LoginForm lf = new LoginForm();
            lf.Show();
            Application.Run();
        }
