    protected void grd_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Button btn = (Button)e.Row.FindControl("btnCheque");
            btn.OnClientClick = "javascript:SearchReqsult(" +
                                DataBinder.Eval(e.Row.DataItem, "Id") + ");";
        }
    }
