    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Loginfrm login = new Loginfrm(); 
        Application.Run(login);
        if (login.LogInSuccesfull)
            Application.Run(new MainForm());
    }
