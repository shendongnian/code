    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
        MembershipUser usr = Membership.GetUser();
        if (usr.IsApproved == false)
        {
            Response.Redirect("~/Login.aspx");
        }
        var p = Profile.GetProfile(usr.UserName);
        /* Displays all current profile information once the page loads */
        FirstName.Text = p.fName;
        LastName.Text = p.lName;
        Address.Text = p.Address;
          Email.Text = usr.Email;
          Company.Text = p.Company;
       }
    }
