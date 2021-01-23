    public IList<YourClass> ParseCustomers(string xmlPath, out isCustomer) {
        var xml = XElement.Load(xmlPath);
        var customerElement = xml.Element("customer");
        isCustomer = customerElement != null && customerElement.Value == "true";
        return xml.Descendants("dataSet").Elements()
                        .Select(m => new <YourClass>
                                         {
                                             Type = m.Name.LocalName,
                                             Value = m.Value
                                         }).ToList();
    }
