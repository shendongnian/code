    protected void rptAlbumsYears_ItemBound(Object Sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataRowView drv = (DataRowView)e.Item.DataItem;
                int Year = Convert.ToInt32(drv["Year"]);
                Repeater Repeater2 = (Repeater)e.Item.FindControl("rptAlbumsYears");
                Panel pnlYear = (Panel)e.Item.FindControl("pnlYear");
                int CurYear = 0;
                CurYear = int.Parse(Request["Year"].ToString());
                if (CurYear == Year)
                {
                    pnlYear.CssClass = "AlbumPageYearListingCurrent";
                }
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
    }
