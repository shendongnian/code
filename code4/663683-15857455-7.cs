    var results = query
        .ToArray() // or .AsEnumerable(), or .ToList(), all will execute the SQL query
        .Select(x => new {
            CustomerContactId = x.CustomerContactID,
            CustomerValue = string.Format("{0} &#09;&emsp;&#09; {1}",
                x.CustomerName, x.Phone)
    });
