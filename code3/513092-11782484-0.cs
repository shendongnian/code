    var orders = new List<order>(
        from myOrder in xmlDoc.Descendants("order")
        select new order {
            IsBulk = Convert.ToBoolean(myOrder.Element("isbulk").Value),
            PurchaseOrder = new PurchaseOrder {
                ID = myOrder.Element("purchaseorder").Element("id").Value,
                Quantity = myOrder.Element("purchaseorder").Element("quantity").Value
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
