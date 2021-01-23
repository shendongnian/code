      ctx.Connection.Open();
      var query = from c in ctx.Customers
                  where c.Country == "Spain"
                  select c;
      using (SqlCommand command = ctx.GetCommand(query) as SqlCommand)
      {
        using (SqlDataReader reader = command.ExecuteReader())
        {
          foreach (Customer c in ctx.Translate<Customer>(reader))
          {
            Console.WriteLine(c.CustomerID);
          }
        }
      }
    }
