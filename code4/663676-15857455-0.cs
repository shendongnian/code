    var tempCustomers =
        from c in db.Customers.ToArray()
        let cc = db.CustomerContacts.ToArray()
           .FirstOrDefault(x => x.CustomerID == c.CustomerID)
        select new
        {
            cc.CustomerContactID,
            CustomerValue = string.Format("{0} &#09;&emsp;&#09; {0}",
                c.CustomerName, cc.Phone)
        };
