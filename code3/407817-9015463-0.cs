    PurchaseOrderItems =
        (from purchaseOrderItem in PO.Descendants("PurchaseOrder").Elements("ProductLineItem")
        select new PurchaseOrderItem
        {
            PONumber = PONumber,
            Description = purchaseOrderItem.Element("comments").Value.Trim(),
            QTY = (short) purchaseOrderItem.Element("OrderQuantity")
                                            .Element("requestedQuantity")
                                            .Element("ProductQuantity"),
            UM = purchaseOrderItem.Element("GlobalProductUnitOfMeasureCode")
                                  .Value.Trim(),
            Cost = (double) purchaseOrderItem.Element("requestedUnitPrice")
                                             .Element("FinancialAmount")
                                             .Element("MonetaryAmount")
        }).ToList();
