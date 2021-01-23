    private void Page_Load()
    {
        if (!IsPostBack)
        {
            // This code should be executed only when the page is being 
            // rendered for the first time not when is responding to a postback 
            // raised by the <runat="server">  controls
            UserInfoCollection userInfo = GetUserInfoCollection();
            foreach (User u in userInfo)
            {
                txtNickname.Text = u.Nickname;
                txtFirstName.Text = u.FirstName;
                txtLastName.Text = u.LastName;
                txtEmail.Text = u.Email;
            }
        }
    }
