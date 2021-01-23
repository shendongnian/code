    protected void Page_Load(object sender, EventArgs e)
    {
        Methods.ExamMethods obj_UserDetails = new Methods.ExamMethods();
        
        if (Request.QueryString["uid"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        else
        {
            if (!Page.IsPostback)
            {
                //read value of uid parameter
                int uid = Request.QueryString["uid"];
                //access database to retrieve user's details
                obj_UserDetails = GetUserDetails(uid);
                lblUserName.Text = obj_UserDetails.FirstName;
            }
        }
    }
