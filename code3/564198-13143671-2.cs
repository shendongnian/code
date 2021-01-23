    var components = new Dictionary<string, AssembleComponent>();
    XDocument doc = XDocument.Load(@"C:\Users\Oli\Desktop\components.xml");
    foreach (XElement el in doc.Root.Descendants()) {
        string name = el.Attribute("name").Value;
        decimal cost = Decimal.Parse(el.Attribute("cost").Value);
        int quantity = Int32.Parse(el.Attribute("quantity").Value);
        components.Add(name, new AssembleComponent{ 
                                 Cost = cost, Quantity = quantity
                             });
    }
