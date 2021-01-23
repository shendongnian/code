    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Gridview1.DataSource = myDataSource;
            GridView1.DataBind();
        }
    }
