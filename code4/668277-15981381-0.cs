    void bindGridview()
    {
        SqlCommand command = new SqlCommand("(SELECT ......", Connection);
        SqlDataAdapter myAdapter = new SqlDataAdapter(command);
        DataTable dt = new DataTable();
        myAdapter.Fill(dt);
    
        command.Connection = connection;
        command.Connection.Open();
        GridView1.AllowPaging = true;
        GridView1.PageSize = 15;
        GridView1.DataSource = dt;
        GridView1.DataBind();
        
    
        command.Connection.Close();
        command.Connection.Dispose();
    }
    
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        bindGridview();
    }
