    protected void grdSettlement_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item.IsInEditMode)
        {
            GridEditableItem item = (GridEditableItem)e.Item;
            RadNumericTextBox txtNo = item.FindControl("txtNo") as RadNumericTextBox;
            txtNo.Value = 7;
        }
    }
