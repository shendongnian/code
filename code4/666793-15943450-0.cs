    <asp:BoundField DataField="LangId" HeaderText="LangId" Visible="false" />
    protected void grdList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
           string langId = e.Row.Cells[columnIndex].Text; // one of the ways
           string langId2 = DataBinder.Eval(e.Row.DataItem, "LangId").ToString(); // one of the other ways
        }
    }
