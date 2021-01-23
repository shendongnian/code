    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e){
      if (e.Row.RowType == DataControlRowType.DataRow)
      {
        SqlDataSource s = (SqlDataSource)e.Row.FindControl("SqlDataSource2");
        s.SelectParameters[0].DefaultValue = e.Row.Cells[0].Text;
      }
    }
