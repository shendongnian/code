    void ItemView_ItemClick(object sender, ItemClickEventArgs e)
    {
        // Navigate to the appropriate destination page, configuring the new page
        // by passing required information as a navigation parameter
        var item = (SampleDataItem)e.ClickedItem;
        var itemId = item.UniqueId;
        if (item.IsCustomNav == false)
        {
            // default
            this.Frame.Navigate(typeof(ItemDetailPage), itemId);
        }
        else
        {
            // custom page
            this.Frame.Navigate(typeof(ItemDetailPage2), itemId);
        }
    }
