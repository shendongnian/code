    protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
    {
         if (e.Item is GridDataItem && !e.Item.IsInEditMode)
         {
             var dataBoundItem = e.Item as GridDataItem;
             var dto = (yourDto)e.Item.DataItem;
             dataBoundItem["Name"] = dto.Name + " + " special";
         }
    }
