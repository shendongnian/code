     void CustomersGridView_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
      if(e.Row.RowType == DataControlRowType.DataRow)
      {
        CheckBox cb = new CheckBox();
        // cb.id = ... and other control setup
        // add your control here:
        e.Row.Cells[0].Controls.Add(cb);
      }
    }
