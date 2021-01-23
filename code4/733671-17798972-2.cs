    static void Main() {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
    
        var loginForm = new Form_Login();
        Application.Run(loginForm);
    
        if (loginForm.LogonResult == LogonStatus.NoLogon) {
            // Do something because there was no logon, or do nothing here and let your app exit.
    
        } else {
            // Launch your application form, passing in the logged on user.
            Application.Run(new AppForm(loginForm.LogonResult));
        }
    }
