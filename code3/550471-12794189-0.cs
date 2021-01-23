    void GridView_RowDataBound (Object sender, GridViewRowEventArgs e)
      {
        // Check for a row in edit mode.
        if(e.Row.RowType == DataControlRowType.DataRow)
        {
          DataRowView rowView = (DataRowView)e.Row.DataItem;
          e.Row.Cells[2].Text=rowView["IsNOWEnabled"].ToString()=="1"?"Enabled":"Disabled";
        }
    }
