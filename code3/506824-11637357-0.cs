    if(i == Sitecore.Context.Item)
    {
        HtmlGenericControl li = e.Item.FindControl("liTabTest");
        li.CssClass = "TabPanelTabbedSelected"
    }
