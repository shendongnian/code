        NWindCustomersDataContext dc = new NWindCustomersDataContext();
        var query = (from c in dc.Customers
                     join o in dc.Orders on c.CustomerID equals o.CustomerID
                     group o by c.CustomerID into g
                     select new
                     {
                         CustomerID = g.Key,
                         Company = (from cust in dc.Customers
                                   where cust.CustomerID == g.Key
                                   select cust).ToList(),
                         Count = g.Select(x => x.OrderID).Distinct().Count()
                     }).OrderByDescending(y => y.Count);
        foreach (var item in query)
        {
            Response.Write("CustomerID: " + item.CustomerID + "</br>" + "CompanyName: " + item.Company[0].CompanyName.ToString() + "</br>");
        }
