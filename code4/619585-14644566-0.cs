    void gridview1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType == DataControlRowType.DataRow)
      {
           CheckBox chk = (CheckBox)e.Row.FindControl("chkBoxID");
           if(Condition)
                 chk.Enabled = false;
      }
    }
