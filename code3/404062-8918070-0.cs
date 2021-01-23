    new XElement("OnlineOrder", ((customerDT.FindByCustomerId(x.CustomerId).GetOrdersRows().Where(o=>o.Type=="Online").Any())
            ? customerDT.FindByCustomerId(x.CustomerId).GetOrdersRows().Where(p1 => p1.Type == "Online").Select(
                (o1 => new List<XAttribute>() { new XAttribute("Amount", o1.Amount),
                        new XAttribute("CardType", o1.CardType),
                        new XAttribute("Quantity", o1.Quantity) }
                ))
            : null)),
