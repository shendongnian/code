        protected void grdConsumers_ItemDataBound(object sender,DataGridItemEventArgs e)
        {
        	if(e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        	{
                // Get your consumerId here     
        		((HyperLink)e.Item.FindControl("Edit")).NavigateUrl = "Vendor.aspx?id=" + consumerId
            }
        }
 
