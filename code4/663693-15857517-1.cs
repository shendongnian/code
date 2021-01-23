    var query=
        from c in db.Customers
        let cc = c.CustomerContacts.FirstOrDefault() // better to use the navigation properties instead
        select new // select the fields you need
        {
            cc.CustomerContactId,
            c.CustomerName,
            Phone = (long?)cc.Phone, // cc could potentially be null this long must also be nullable
        };
    var tempCustomers =
        from x in query.AsEnumerable() // LINQ to Objects
        select new // now you can do what you want to the data
        {
            x.CustomerContactId,
            CustomerValue = x.CustomerName + " &#09;&emsp;&#09; " + x.Phone,
        };
