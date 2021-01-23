    protected void Menu1_MenuItemDataBound(object sender, MenuEventArgs e)
    {
        string Url = ((SiteMapNode)e.Item.DataItem).Url;
        Response.Redirect(Url);
    }
