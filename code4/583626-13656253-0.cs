    protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridEditableItem && e.Item.IsInEditMode)
        {
            GridEditableItem item = e.Item as GridEditableItem;
            TextBox txtFormat = (item.FindControl("txtFormat") as TextBox);
            txtFormat.Text = "Your text";
        }
    }
