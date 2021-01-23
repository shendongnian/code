    protected void DataList1_ItemDataBound(object sender, 
                                 DataListItemEventArgs e) 
    {
         if (e.Item.ItemType == ListItemType.Item || 
             e.Item.ItemType == ListItemType.AlternatingItem)
         { 
             //Add eventhandlers for highlighting 
             //a DataListItem when the mouse hovers over it.
             e.Item.Attributes.Add("onmouseover", 
                    "this.oldClass = this.className;" + 
                    " this.className = 'EntryLineHover'"); 
             e.Item.Attributes.Add("onmouseout", 
                    "this.className = this.oldClass;");
             //Add eventhandler for simulating 
             //a click on the 'SelectButton'
             e.Item.Attributes.Add("onclick", 
                    this.Page.ClientScript.GetPostBackEventReference(
                    e.Item.Controls[1], string.Empty));
         }
    }
