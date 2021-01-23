    private static HtmlGenericControl FindBody(Page page)
    {
        MasterPage masterPage = GetTopLevelMasterPage(page);
        if (masterPage == null) return null;
        foreach(Control c in masterPage.Controls)
        {
            HtmlGenericControl g = c as HtmlGenericControl;
            if (g == null) continue;
            if (g.TagName.Equals("body", StringComparison.OrdinalIgnoreCase)) return g;
        }
        return null;
    }
