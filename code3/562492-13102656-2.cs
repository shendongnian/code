    public int GetTotalCostForAnOrder(int OrderID)
    {
        XElement doc=XElement.Load("c:\\yourXML.xml");
        decimal totalPrice=doc.DescendantsAndSelf("Order")
        .Where(x=>x.Attribute("id").Value==OrderID)
        .Select(y=>y.Element("Items")).Elements("Item")
        .Select(z=>decimal.Parse(z.Element("TotalCost").Value)).ToList().Sum();
        return totalPrice;
    }
