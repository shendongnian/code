    protected void RowDataBound(object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType == DataControlRowType.DataRow)
      {
        if ((e.Row.RowState & DataControlRowState.Edit) > 0)
        {
             // you code logic
        }
      }
    }
