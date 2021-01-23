    public void Login_OnClick(object sender, EventArgs args)
    {
       if (Membership.ValidateUser(UsernameTextbox.Text, PasswordTextbox.Text))
          FormsAuthentication.RedirectFromLoginPage(UsernameTextbox.Text, NotPublicCheckBox.Checked);
       else
         Msg.Text = "Login failed. Please check your user name and password and try again.";
    }
