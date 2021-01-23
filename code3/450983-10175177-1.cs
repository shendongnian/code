    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string usr = Session["SessionUserName"].ToString();
            user = (from u in context.Users
                    where u.username.Equals(usr)
                    select u).FirstOrDefault();
            txtFName.Text = user.firstName;
            txtLName.Text = user.lastName;
            txtCompany.Text = user.companyName;
            txtEmail.Text = user.email;
            txtPhone.Text = user.phoneNumber;
        }
    }
