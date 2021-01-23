    protected void OnAuthenticate(object sender, AuthenticateEventArgs e)
        {
     if (txtUsername.Text == "admin" && txtPassword.Text == "1234")
            {
                e.Authenticated = true;
            }
            else {
                e.Authenticated = false;
            }    
    
    }
