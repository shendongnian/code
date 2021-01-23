      ctx.Connection.Open();
      var query = from c in ctx.Customers
                  where c.Country == "Spain"
                  select c;
      ctx.BeginQuery(query, result =>
      {
        foreach (Customer c in ctx.EndQuery<Customer>(result))
        {
          Console.WriteLine(c.CustomerID);  
        }
      }, null);
      Console.ReadLine();   
    }
