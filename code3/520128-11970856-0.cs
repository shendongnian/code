    // set orderID, shippingDetails above
    
    foreach(var item in cartItems)
    {
    	ProcessedItems processedItem = new ProcessedItems();
    	processedItem.OrderID = orderID;
        processedItem.ProductID = item.Product.ProductID;
        processedItem.Name = item.Product.Name;
        processedItem.Description = item.Product.Description;
        processedItem.Price = item.Product.Price;
        processedItem.Category = item.Product.Category;
        processedItem.ImageName = item.Product.ImageName;
        processedItem.Image2Name = item.Product.Image2Name;
        processedItem.Image3Name = item.Product.Image3Name;
    
        processedItem.BuyerName = shippingDetails.Name;
        processedItem.Line1 = shippingDetails.Line1;
        processedItem.Line2 = shippingDetails.Line2;
        processedItem.Line3 = shippingDetails.Line3;
        processedItem.City = shippingDetails.City;
        processedItem.State = shippingDetails.State;
        processedItem.Zip = shippingDetails.Zip;
        processedItem.Country = shippingDetails.Country;
        SubmitItem(processedItem);
    
    }
    
    public void SubmitItem(ProcessedItems processedItem)
    {
        processedItem.Status = "Submitted";
        processedItems.SaveItem(processedItem);
    }
