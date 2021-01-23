    DialogResult result = DialogResult.Cancel;
    while (result != DialogResult.OK)
    {
        using (LoginForm loginForm = new LoginForm())
        {
            result = loginForm.ShowDialog();
            if (result != DialogResult.OK) continue;
            if (!AuthenticateCredentialsSomehow.Authenticate(loginForm.Username, loginForm.Password))
            {
                MessageBox.Show("Login Failed!");
                result = DialogResult.Cancel;
                continue;
            }
            MainForm mainForm = new MainForm(loginForm.Username, loginForm.Password);
            Application.Run(mainForm);
        }
    }
