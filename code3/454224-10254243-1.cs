    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            TxtFilter1.Text = Request.QueryString["filter1"] ?? "";
            TxtFilter2.Text = Request.QueryString["filter2"] ?? "";
            TxtFilter3.Text = Request.QueryString["filter3"] ?? "";
            // etc.
        }
    }
