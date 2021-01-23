    protected void dtlSearchDetails_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            var imgBtn = e.Item.FindControl("dtlImgDownload") as ImageButton;
            ScriptManager.GetCurrent(this.Page).RegisterPostBackControl(imgBtn);
            // your other code goes here.
        }
    }
