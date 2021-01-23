     XDocument doc = XDocument.Load("Orders.xml");
     var data = from item in doc.Descendants("Order")
                select new
                {
                    OrderID = item.Element("OrderID").Value,
                    POnumber = item.Element("PurchaseOrderNumber").Value,
                    OrderDate = item.Element("OrderPlacedDate").Value,
                    PFirstName = item.Element("purchasingContact").Element("FirstName").Value,
                    Pids = item.Element("CurrentOrderDetails").Elements("ProductsId").Select(e => e.Value).ToList()
                };
