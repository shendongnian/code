    protected void ResultItem_DataBound(object sender, RadListViewItemEventArgs e)
        {        
            var dItem = e.Item as RadListViewDataItem;
            var dObj = dItem.DataItem as QT.FullTicket;
            //if no read date, mark as unread (bold)
            if (dObj.AssigneeView == null)
            {            
                var headerLabel = e.Item.FindControl("lblHeader") as Label;
                headerLabel.Style.Add("Font-Weight", "Bold");
                headerLabel.Style.Add("Color", "Orange");
            }
        }
