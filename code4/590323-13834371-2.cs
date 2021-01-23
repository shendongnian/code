    private List<Customer> GetCustomerData()
    {            
        XDocument xdoc = XDocument.Load(path_to_xml);
        return xdoc.Descendants("customer")
                    .Select(c => new Customer()
                    {
                        Id = (string)c.Element("id"),
                        Name = (string)c.Element("name"),
                        Address = (string)c.Element("address"),
                        Country = (string)c.Element("country"),
                        City = (string)c.Element("city"),
                        Orders = c.Descendants("order")
                                    .Select(o => new Order()
                                    {
                                        Id = (int)o.Element("id"),
                                        Date = (DateTime)o.Element("orderdate"),
                                        Total = (decimal)o.Element("total")
                                    }).ToList()
                    }).ToList();
    }
