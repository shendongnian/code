    protected void grd_rowdatabound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Button btn = (Button)e.Row.FindControl("btncheque");
            btn.OnClientClick = String.Format("return SearchReqsult('{0}')", DataBinder.Eval(e.Row.DataItem, "ID"));
        }
    }
