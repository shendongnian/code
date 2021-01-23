    protected void GridView_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
        CheckBox c = e.Row.FindControl("chkDownloaded");
        (((YourClassName)e.Row.DataItem).YourPropertyName) == null ? false : ((YourClassName)e.Row.DataItem).YourPropertyName;
    }
