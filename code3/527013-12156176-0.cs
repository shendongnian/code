    public DataSet GetDaysForEvents(string eventId)
    {
    	var ds = new DataSet();
    	using(var connection = new SqlConnection("ConnectionString"))
    	{
    		using(var cmd = new SqlCommand("storedProcedureName", connection){ CommandType = CommandType.StoredProcedure })
    		{
    			cmd.Parameters.AddWithValue("@EventId", eventId);
    			using(var adapter = new SqlDataAdapter(cmd))
    			{
    				adapter.Fill(ds);
    			}
    		}
    	}
    	return ds;
    }
