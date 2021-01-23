    protected void NavBarSearchItemNoSearchItem_OnClick(object sender, EventArgs e)
    {
        var searchFieldTbx = NavBarSearchItemNo;
        var navBarSearchCatHiddenField = NavBarSearchCatHiddenField;
        var term = searchFieldTbx != null ? searchFieldTbx.Text : "";
        if (term.Length > 0) //There is actually something in the input box we can work with
        {
            //Response.Redirect(Url.GetUrl("SearchResults", term));
            Response.Redirect(ResolveClientUrl("~/Web/SearchResults.aspx?term=" + term + "&cat=" + navBarSearchCatHiddenField.Value));
        }
    }
