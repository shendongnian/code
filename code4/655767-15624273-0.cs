    protected void ButtonLogin_Click(object sender, EventArgs e)
    {
        using(BerouDataContext Data = new BerouDataContext())
        {
          var UsernameCheck = UserNameTextBox.Text;
          var PasswordCheck = PasswordTextBox.Text;
          var UserExist = Data.Memberships.Single(s => s.Username == UsernameCheck);
          if (UserExist == null || UserExist.Password != PasswordCheck)
          {
            LabelLoginValidity.Text = "Login Details are incorrect.";
          }
          else
          {
            FormsAuthentication.SetAuthCookie(UserNameTextBox.Text, false);
            LabelLoginValidity.Text = "Login Successfull!";
          }
       }
    }
