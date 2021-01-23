    protected void ListView1_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
    
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
               
                Image imgActive = (Image)e.Item.FindControl("imgActive");
                System.Data.DataRowView rowView = e.Item.DataItem as System.Data.DataRowView;
                string value = rowView["Enable"].ToString();
                if (value == "1")
                {
                    imgActive.ImageUrl="~/images/yes.gif" 
                }
                else
                {
                    imgActive.ImageUrl="~/images/no.gif" 
                }
            }
        }
