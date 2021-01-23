    listingDataView.Filter += new FilterEventHandler(ShowOnlyBargainsFilter);
    private void ShowOnlyBargainsFilter(object sender, FilterEventArgs e)
    {
        AuctionItem product = e.Item as AuctionItem;
        if (product != null)
        {
            // Filter out products with price 25 or above 
            if (product.CurrentPrice < 25)
            {
                e.Accepted = true;
            }
            else
            {
                e.Accepted = false;
            }
        }
    }
