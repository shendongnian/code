    void Button1_Click(object sender, EventArgs e)
    {
        exporting = true;
        RadGrid1.Rebind();
        RadGrid1.MasterTableView.ExportToExcel();
    }
    
    void RadGrid1_ItemCreated(object sender, Telerik.Web.UI.GridItemEventArgs e)
    {
        if (exporting && e.Item.ItemType == Telerik.Web.UI.GridItemType.FilteringItem)
        {
            e.Item.Visible = false;
        }
    }
