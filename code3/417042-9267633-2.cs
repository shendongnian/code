    protected void GridView1_Sorting(object sender, GridViewSortEventArgs e) 
    {
        //Retrieve the table from the session object.
        DataTable dt = Session["MainData"] as DataTable;
        if (dt == null) return;
        
        //Sort the data
        dt.DefaultView.Sort = e.SortExpression + " " +
                              GetSortDirection(e.SortExpression);
        this.GridView1.DataSource = dt;
        this.GridView1.DataBind();
    }
