    var query = from order in xmlDoc.Descendants(ns + "Order")
                from orderItem in order.Elements(ns + "OrderItem")
                select new
                {        
                    amazonOrdeID = order.Element(ns + "AmazonOrderID").Value,
                    merchantOrderID = order.Element(ns + "MerchantOrderID ").Value,
                    orderStatus = order.Element(ns + "OrderStatus ").Value,
                    asin = OrderItem.Element(ns + "ASIN").Value,
                    quantity = OrderItem.Element(ns + "quantity").Value
                };
