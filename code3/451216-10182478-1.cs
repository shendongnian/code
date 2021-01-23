    public void grd_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            HtmlGenericControl removeProductButton = (HtmlGenericControl)e.Item.FindControl("removeProductButton");
    
            Button removeProductButtonHidden = (Button)e.Item.FindControl("removeProductButton_hidden");
    
            removeProductButton.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(removeProductButtonHidden, ""));
        }
    }
