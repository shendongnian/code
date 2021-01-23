    protected void Page_Load(object sender, EventArgs e)
    {
        userName = Request.QueryString["UserName"].ToString();
        if(!IsPostBack)
            RetriveProfile();
    }
