    using (NorthwindDataContext ctx = new NorthwindDataContext())
    {
      ctx.Connection.Open();
      var query = from c in ctx.Customers
                  where c.Country == "Spain"
                  select c;
      using (SqlCommand command = ctx.GetCommand(query) as SqlCommand)
      {
        SqlDataReader reader = null;
        ManualResetEvent waitEvent = new ManualResetEvent(false);
        command.BeginExecuteReader(result =>
        {
          try
          {
            reader = command.EndExecuteReader(result);            
          }
          catch (SqlException ex)
          {
            Console.WriteLine("Sorry {0}", ex.Message);
          }
          finally
          {
            waitEvent.Set();
          }
        }, null);
        waitEvent.WaitOne();
        if (reader != null)
        {
          foreach (Customer c in ctx.Translate<Customer>(reader))
          {
            Console.WriteLine(c.CustomerID);
          }
        }
      }
    }
