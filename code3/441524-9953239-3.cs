        protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
        {
     
    if (e.Item is GridEditableItem && e.Item.IsInEditMode && e.Item is GridDataInsertItem)
            {
                  GridEditableItem item = (GridEditableItem)e.Item;
                  RadNumericTextBox txtNo = item.FindControl("txtNo") as RadNumericTextBox;
                  txtNo.Value = 7;
            }
     
    }
