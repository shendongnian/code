    var query = from c in Customer.GetCustomers()
                where c.City == "Mexico D.F.";
    foreach (var c in query)
    {
        Console.WriteLine("{0} {1}", c.City, c.ContactName);
    }
