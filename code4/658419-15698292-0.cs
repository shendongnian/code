    ...
    else 
    {
        txtItemID.Text = "";
        lblErr.Content = "";
        SaleItem newItem = new SaleItem() {
                        Num = items.Count + 1,
                        ItemID = itm.ItemID,
                        Name = itm.Name,
                        Price = decimal.Round(itm.Price, 2, MidpointRounding.AwayFromZero),
                        Quantity = 1 };
         newItem.PropertyChanged += 
                 new PropertyChangedEventHandler(newSaleItem_PropertyChanged);
        items.Add(newItem);
     }
     ...
