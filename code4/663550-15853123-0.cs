    protected void grid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        GridView1.DataSource = us.GetProducts("Playstation");
        GridView1.DataBind();
    }
