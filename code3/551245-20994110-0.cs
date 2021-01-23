    protected void dlfilteritem_ItemDataBound(object sender, DataListItemEventArgs e) {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {            
                RadioButtonList RBL = ((RadioButtonList)e.Item.FindControl("PopularCity"));
                RBL.DataSource = dataTable; 
                RBL.DataBind();
            }
        }
