    // using utilizes the IDisposable-Interface, whcih exists to limit the lifetime
    // of certain objects, especially those which use native resources which
    // otherwise might be floating around.
    using(YourConnectionType connection = new YourConnectionType("connectionstring"))
    {
    	connection.Open(); // You might want to have this in a try{}catch()-block.
    	
    	using(YourCommandType command = connection.CreateCommand())
    	{
    		command.CommandText = "select product_price from product where product_name=@NAME;";
    		command.Parameters.Add("NAME", YourTypes.VarChar);
    		command.Parameters[0].Value = x; // For your own sanity sake, rename that variable!
    		
    		using(YourReaderType reader = command.ExecuteReader())
    		{
    			while(reader.Read()) // If you're expecting only one line, change this to if(reader.Read()).
    			{
    				Price_label.Content = reader.GetString(0);
    			}
    		}
    	}
    } // No need to close the conenction explicit, at this point connection.Dispose()
      // will be called, which is the same as connection.Close().
