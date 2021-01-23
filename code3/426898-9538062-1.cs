     // Earlier query as before...
     select new
     {
         PurcaseOrderNo = purchaseOrder.Element(ns + "po-number").Value,
         PurchaseDate = purchaseOrder.Element(ns + "po-date").Value,
         CustomerFullName = purchaseOrder.Element(ns + "customer-name").Value,
         ItemIds = purchaseOrder.Elements(ns + "po-line")
                                .Elements(ns + "po-line-header")
                                .Elements(ns + "item-id")
                                .Select(x => x.Value)
                                .ToList()
     };
