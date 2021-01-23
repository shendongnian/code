    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string culture = Request.QueryString["culture"];
        }
    }
