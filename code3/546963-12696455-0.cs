    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.ServerVariables["AUTH_USER"] != null
            && !Request.ServerVariables["AUTH_USER"].Equals(""))
        {
            login.Visible = false;
            logout.Visible = true;
            btnLogout.Text = "Logout " + Request.ServerVariables["AUTH_USER"];
        }
        else
        {
            login.Visible = true;
            logout.Visible = false;
            // Only check the login cookie if we are not dealing with a form submission.
            if (!Page.IsPostBack)
            {
                CheckLoginCookie();
            }
        }
    }
