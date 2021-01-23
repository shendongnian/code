    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["SessionUserName"] != null)
            {
                string usr = Session["SessionUserName"].ToString();
                DataClasses1DataContext context = new DataClasses1DataContext();
                User user = (from u in context.Users
                             where u.username.Equals(usr)
                             select u).FirstOrDefault();
                if (user != null)
                {
                    txtFName.Text = user.firstName;
                    txtLName.Text = user.lastName;
                    txtCompany.Text = user.companyName;
                    txtEmail.Text = user.email;
                    txtPhone.Text = user.phoneNumber;
                }
                else
                {
                    //--- handle user not found error
                }
            }
            else
            {
                //--- handle session is null
            }
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (Session["SessionUserName"] != null)
        {
            string usr = Session["SessionUserName"].ToString();
            try
            {
                DataClasses1DataContext context = new DataClasses1DataContext();
                User nUser = (from u in context.Users
                              where u.username.Equals(usr)
                              select u).FirstOrDefault();
                //make the changes to the user
                nUser.firstName = txtFName.Text;
                nUser.lastName = txtLName.Text;
                nUser.email = txtEmail.Text;
                if (!String.IsNullOrEmpty(txtPhone.Text))
                    nUser.phoneNumber = txtPhone.Text;
                if (!String.IsNullOrEmpty(txtCompany.Text))
                    nUser.companyName = txtCompany.Text;
                nUser.timeStamp = DateTime.Now;
                //submit the changes
                context.SubmitChanges();
                Response.Redirect("Projects.aspx");
            }
            catch (Exception ex)
            {
                //--- handle update error
            }
        }
        else
        {
            //--- handle null session error
        }
    }
