    protected void LoginButton_Click(object sender, EventArgs e)
    {
        // Validate the user against the Membership framework user store
        if (Membership.ValidateUser(Username.Value, Password.Value))
        {
            // Log the user into the site
            FormsAuthentication.RedirectFromLoginPage(UserName.Value, RememberMe.Checked);
        }
        // If we reach here, the user's credentials were invalid
        InvalidCredentialsMessage.Visible = true;
    }
