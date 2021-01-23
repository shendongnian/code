    foreach (var customer in customers)
    {
        foreach (var property in typeof (Customer).GetProperties())
        {
            if (property.IsDefinded(typeof(ShowAttribute))
            {
                Console.WriteLine(property.GetValue(customer, new object[0]));
            }
        }
    }
