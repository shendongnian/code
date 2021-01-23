     protected void GridView1_RowDataBound(Object sender, GridViewRowEventArgs e)
     {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DropDownList ddl = (DropDownList)e.Row.FindControl("ddlYesNo");
            ddl.SelectedValue = 
              ((System.Data.DataRowView)e.Row.DataItem) ["dataColName"].ToString();
        }
     }
