    protected void gvMyGrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ImageButton ibtn = (ImageButton)e.Row.FindControl("btnExportRed");
            if(ibtn != null)
            {
                ibtn.ClientClick = "return confirm('" + GetConfirmExportMessage() + "');";
            }
        }
    }
