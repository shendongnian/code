    protected void UserGridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HyperLink EditHyperLink = (HyperLink)e.Row.FindControl("EditHyperLink");
            EditHyperLink.NavigateUrl=("EditUserInfo.aspx?key=" + oDataTable.Rows[e.Row.DataItemIndex]["UserCode"], 650, 500, true);
        }
    }
