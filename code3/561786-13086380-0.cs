    void bindGrid()
    {
       grid.DataSource = getRunDates();
       grid.DataBind();
    }
    DataTable getRunDates()
    {
       DataTable dt = new DataTable();
       dt.Columns.Add("TempID");
       dt.Columns.Add("RunDate");
       dt.Rows.Add(new object[] { 1, "20-May-2012" });
       dt.Rows.Add(new object[] { 2, "21-May-2012" });
       dt.Rows.Add(new object[] { 3, "10-May-2012" });
       dt.Rows.Add(new object[] { 4, "20-May-2012" });
       return dt;
    }
    protected void grid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
       if (e.Row.RowType == DataControlRowType.DataRow)
       {
          DataTable dt = new DataTable();
          dt = getRunDates();
          DropDownList ddl = e.Row.FindControl("DropDownList1") as DropDownList;
    
          ddl.DataTextField = "RunDate";
          ddl.DataValueField = "TempID";
          ddl.DataSource = dt;
          ddl.DataBind();
    
          ddl.SelectedValue = ((System.Data.DataRowView)(e.Row.DataItem)).Row["TempId"].ToString();
        }
    }
