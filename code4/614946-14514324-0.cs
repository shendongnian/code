    protected void AccessRecordsGrid_OnItemCreated(object sender, Telerik.Web.UI.GridItemEventArgs e)
    {
        if (e.Item is GridEditableItem && e.Item.IsInEditMode)
        {
            //the item is in edit mode    
            GridEditableItem editedItem = e.Item as GridEditableItem;
            RadComboBox comboEditAccessGroup = (RadComboBox)editedItem.FindControl("combo_editAccessGroup");
        }
    }
