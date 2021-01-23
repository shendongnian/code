    protected void gvEntity_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
           CheckBox cbAttachClrReq = (CheckBox) e.Row.FindControl("chkAdd");
    
          if (cbAttachClrReq.Checked)
          {
              e.Row.Enabled = false;
          }       
        }
    
    }
