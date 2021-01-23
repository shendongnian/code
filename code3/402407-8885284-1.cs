    protected void gv_RowDataBound(object sender, GridViewRowEventArgs e) 
    { 
        ...
        if (e.Row.RowType != DataControlRowType.Pager) 
        {
            if (ddlDivision.SelectedValue == "ALL")
            {
               // only check for pager row, all other rows including header/footer should be hidden
               e.Row.Cells[0].Visible = false; 
            }
        }
        ...    
    } 
