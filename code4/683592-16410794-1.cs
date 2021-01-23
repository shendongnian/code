    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e) {
      if (e.Row.RowType == DataControlRowType.DataRow)
       {
         // find DataSource used for nested GridView (could be SqlDataSource)
         AccessDataSource s = (AccessDataSource)e.Row.FindControl("dsMusic");
         // assign parameter’s default value from the DataKeys in GridView1
         s.SelectParameters[0].DefaultValue = Convert.ToString(((GridView)sender).DataKeys[e.Row.RowIndex].Values["Composer"]);
       }
    }
