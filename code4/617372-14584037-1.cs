    public ActionResult Index()
    {
    	var model = new List<ProductViewModel>();
    	
    	// create a connection
    	SqlConnection con = new SqlConnection("your_connection_string");	
    	try 
    	{
    		// open the conneciton
    		con.Open();
    		
    		// prepare a command
    		SqlCommand command = new SqlCommand("You_Stored_Procedure_Name",con);	
    		command.CommandType = CommandType.StoredProcedure;
    		
    		// add parameters if you need
    		// command.Parameters.AddWithValue("ParameterName", value);
    		
    		// execute a reader with the command
    		using (var reader = command.ExecuteReader())
    		{
    			// loop in the result and fill the list
    			while (reader.Read())
    			{
    				// add items in the list
    				model.Add(new ProductViewModel() 
    						{
    							Id = (int)reader["Id"],
    							Name = reader["Name"].ToString(),
    							Price = (decimal)reader["Price"]
    							// other properties
    						});
    			}
    		}		
    	}
    	catch 
    	{
    	}
    	finally 
    	{	
    		con.Close();
    	}
    	
    	return View(model);
    }
