    if (!Page.IsPostback)
    {
        string email = Membership.GetUser(User.Identity.Name).Email; 
        MembershipUser currentUser = Membership.GetUser(); 
        string UserId = currentUser.ProviderUserKey.ToString(); 
 
        TextBox2.Text = email; 
        TextBox3.Text = UserId; 
    }
