    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow) 
        { 
             Button btn = (Button)e.Row.FindControl("btnCheque");
             btn.Attributes.Add("OnClick","SearchReqsult(this.id);");
        } 
     }
