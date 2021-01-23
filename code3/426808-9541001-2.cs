    xmlDoc = XDocument.Parse(sr.ReadToEnd());
            
    XNamespace ns = "w3.org/2001/XMLSchema-instance";
    var query = from order in xmlDoc.Descendants(ns + "Order")
                from orderItem in order.Elements(ns + "OrderItem")
                select new
                {        
                    amazonOrdeID = order.Element(ns + "AmazonOrderID").Value,
                    merchantOrderID = order.Element(ns + "MerchantOrderID ").Value,
                    orderStatus = order.Element(ns + "OrderStatus ").Value,
                    asin = orderItem.Element(ns + "ASIN").Value,
                    quantity = orderItem.Element(ns + "quantity").Value
                };
