    // The following line of code requires
    // a MARS-enabled connection.
    productReader = productCmd.ExecuteReader();
    using (productReader)
    {
      while (productReader.Read())
      {
    	Console.WriteLine("  " +
    	  productReader["Name"].ToString());
      }
    }
