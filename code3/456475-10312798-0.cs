     [STAThread]
            static void Main()
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Login oLogin = new Login();
                oLogin.ShowDialog();
                Application.Run(new Main_Usr());
            }
