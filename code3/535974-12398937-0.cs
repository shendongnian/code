    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string email2 = Membership.GetUser(User.Identity.Name).Email;
            MembershipUser currentUser = Membership.GetUser();
            string UserId2 = currentUser.ProviderUserKey.ToString();
        
            TextBox2.Text = email2;
            TextBox3.Text = UserId2;
    
        }
    }
