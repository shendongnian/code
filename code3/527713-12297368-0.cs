     static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginWindow());
            start();
        }
    
     public static void start()
        {
            if (TimeRegisterApI.isLoggedIn())
            {
                MainWindow w = new MainWindow();
                Application.Run(w);
            }
        }
