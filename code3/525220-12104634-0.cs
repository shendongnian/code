    foreach(DevExpress.Web.ASPxGrid.ASPxGridItem Item in ASPxGrid1.Items)
    
        if(Item.ItemType == DevExpress.Web.ASPxGrid.ItemType.Item || Item.ItemType == DevExpress.Web.ASPxGrid.ItemType.AlternatingItem) {
    
            CheckBox edit = Item.FindControl("Checkbox1") as CheckBox;
    
            if(edit != null) {
    
                ... // your code is here
    
            }
