    protected void Page_Load(object sender, EventArgs e)
    {
            if (!IsPostBack)
            {
                gridView1.DataSource = string.Empty;
                gridView1.DataBind();
            }
    }
