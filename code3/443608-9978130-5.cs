    using (NorthwindDataContext ctx = new NorthwindDataContext())
    {
      ctx.Connection.Open();
      var query = from c in ctx.Customers
                  where c.Country == "Spain"
                  select c;
      ctx.BeginQuery(query, result =>
      {
        foreach (var v in ctx.EndQuery(result, 
          x => new { 
            Id = (string)x["CustomerID"], 
            Name = (string)x["CompanyName"] 
          }))
        {
          Console.WriteLine(v);  
        }
      }, null);
      Console.ReadLine();   
    }
