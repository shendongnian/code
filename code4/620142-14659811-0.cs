    void gridview1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType == DataControlRowType.DataRow)
      {
           CheckBox chk = (CheckBox)e.Row.FindControl("chkBoxID");
           if(DataBinder.Eval(e.Row.DataItem, "datasourceColumnName").ToString() == "someval")
                 chk.Enabled = false;
      }
    }
