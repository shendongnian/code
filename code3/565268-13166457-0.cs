    protected void LoginUser_LoggedIn(object sender, EventArgs e)
    {
        var usernameTextBox = (TextBox)LoginUser.FindControl("UserName");
        string username = usernameTextBox.Text;
        MembershipUser user = Membership.GetUser(username);
        Guid userId = (Guid)user.ProviderUserKey;
    }
