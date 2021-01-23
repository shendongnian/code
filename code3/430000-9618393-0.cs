    private static MasterPage GetTopLevelMasterPage(Page page)
    {
        MasterPage result = page.Master;
        if (page.Master == null) return null;
        while(result.Master != null)
        {
            result = result.Master;
        }
    }
    private static Control FindBody(Page page)
    {
        MasterPage masterPage = GetTopLevelMasterPage(page);
        if (masterPage == null) return null;
        return masterPage.FindControl("MasterPageBodyTag");
    }
    private void UpdateBodyCss()
    {
        Control body = FindBody(this);
        if(body != null) body.Attributes.Add(...);
    }
