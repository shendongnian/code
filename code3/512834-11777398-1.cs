    void Page_Load(object sender, EventArgs e)
    {
        ...
        if (!this.IsPostBack)
        {
            RadListView1.DataSource = dataSource;
            RadListView1.DataBind();
        }
        ...
    }
