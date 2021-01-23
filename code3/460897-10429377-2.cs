    var result = from item in context.table
        select new {
             field1 = ... ,
             field2 = ... ,
             field3 = ... };
    
    if (result.Any())
    {
        Type t = result.First().GetType();
        foreach (PropertyInfo p in t.GetProperties())
        {
            // Get the name of the prperty
            Console.WriteLine(p.Name);
        }
    }
