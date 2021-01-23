    private void btnLogin_Click(object sender, EventArgs e)
    {
        if (Login(tboxUserName.Text, tboxPassword.Text))
        {
            // Log in was successful, do something...
        }
        else
        {
            // Log in was NOT successful, inform the user...
        }
    }
