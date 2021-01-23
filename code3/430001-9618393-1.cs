    private static MasterPage GetTopLevelMasterPage(Page page)
    {
        MasterPage result = page.Master;
        if (page.Master == null) return null;
        while(result.Master != null)
        {
            result = result.Master;
        }
    }
    private static HtmlGenericControl FindBody(Page page)
    {
        MasterPage masterPage = GetTopLevelMasterPage(page);
        if (masterPage == null) return null;
        return masterPage.FindControl("MasterPageBodyTag") as HtmlGenericControl;
    }
    private void UpdateBodyCss()
    {
        HtmlGenericControl body = FindBody(this);
        if(body != null) body.Attributes.Add(...);
    }
