    protected void Login_Authenticate(object sender, EventArgs e)
    {
        string username = txtUsername.Text;
        string password = CalculateMD5(txtPassword.Text);
        My.Namespace.Login login = new My.Namespace.Login(username, password);
    }
