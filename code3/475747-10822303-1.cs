    protected void Page_Load(object sender, EventArgs e)
    {
        this.FillGrid();
    }
    protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        this.GridView1.SelectedIndex = e.NewSelectedIndex;
        this.FillGrid();
    }
    private void FillGrid()
    {
        this.GridView1.DataSource = new[] { "Hello", "World" };
        this.GridView1.DataBind();
    }
