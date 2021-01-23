    var orders = new List<order>(
        from myOrder in xmlDoc.Descendants("order")
        let purchaseOrder = myOrder.Element("purchaseorder")
        select new order {
            IsBulk = Convert.ToBoolean(myOrder.Element("isbulk").Value),
            PurchaseOrder = new PurchaseOrder {
                ID = purchaseOrder.Element("id").Value,
                Quantity = purchaseOrder.Element("quantity").Value
            },
            ListOfProds = new List<prod>(
                from product in myOrder.Descendants("prod")
                let loop = product.Element("loop")
                select new prod
                {                
                    Seq = product.Element("seq").Value,
                    IssueType = product.Element("issuetype").Value,
                    Proxy = loop.Element("proxy").Value,
                    ServiceCode = loop.Element("servicecode").Value
                }
            )
        }
    );
