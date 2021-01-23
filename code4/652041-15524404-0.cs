    protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Dictionary<string,string> allowedUrls = LoadAllowedURLs();
    
                if (!allowedUrls.ContainsKey(Request.Path))
                {
                    Response.Redirect("Some_default_redirect_page.aspx");   
                }
            }
        }
