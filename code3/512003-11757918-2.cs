    MasterPage master = Page.Master;
    if (master != null)
    {
        tbl = master.FindControl("tbl_login") as HtmlTable;
        if (tbl != null)
        {
            tbl.IsVisible = false;
        }
    }
