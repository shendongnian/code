    protected void ListView1_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                YourControl  VideoLink1= e.Item.FindControl("VideoLink1") as YourControl ;
                if(VideoLink1!= null)
                {
                    YourClass obj = ((YourClass)(((System.Web.UI.WebControls.ListViewDataItem)(e.Item)).DataItem));
                   VideoLink1.TextProperty = obj .TextProperty ;
               }    
           }
    }
