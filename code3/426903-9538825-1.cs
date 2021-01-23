    XElement xfile = // load your file
    PurchaseOrder[] orders = xfile.GetEnumerable("purchase-order", xe => new PurchaseOrder(xe)).ToArray();
    
    foreach(PurchaseOrder order in orders)
    {
        // do something with the order number
        int number = order.Number;
    
        ...
    
        foreach(POLine line in order.Lines)
        {
            // do something with the item name
            string itemName = line.ItemName;
            ...
        }
    
        ...
    }
