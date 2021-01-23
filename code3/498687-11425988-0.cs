    protected void grdList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lbl = (Label)(e.Row.FindControl("lblTotal"));
            lbl.Text = String.Format("{0:n}", Total);
        }
    }
