    protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
    
                          // get image option if in grid or from datasource using DataBinder.Eval()
                        Image im1 = (Image)e.Item.FindControl("Image1");                                     
                        im1.Width = "Your Width";      
                        im1.height = "Your Height";
    
            }
        }
