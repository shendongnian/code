     protected void Page_Load(object sender, EventArgs e)
            {   
    
    if (!IsPostBack)
    {
     if (MySessionHelper.UserInfo != null)
                {
                    Response.Redirect("http://example.com:23456/", false);
                }
    }
    }
