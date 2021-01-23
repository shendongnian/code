    MasterPage master = Page.Master;
    if (master != null)
    {
        tbl = (HtmlTable)master.FindControl("tbl_login");
        if (tbl != null)
        {
            tbl.IsVisible = false;
        }
    }
