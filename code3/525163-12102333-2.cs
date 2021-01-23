    customerlist = db.Customers
        .Where(u => (u.Cust_ID+u.Given_Name+u.Surname).Contains(searchstring))
        .AsEnumerable()  //EDIT: was ToArray()
        .OrderBy(u => Int32.Parse(u.Cust_ID.SubString(1)))
        .ToList();
