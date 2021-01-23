    User u = new User();
    if (u.AuthenticateUser(txtUsername.Text, txtPassword.Text))
    {
       Session.Add("UserSeshAuthenticated", true);
       Session.Add("oUser", u);
       Response.Redirect("Dashboard.aspx");
    }
