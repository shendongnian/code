    using (var conn = new SqlConnection(connectionString))
    using (var bulkCopy = new SqlBulkCopy(conn))
    {
    	conn.Open();
    	{
    		bulkCopy.DestinationTableName = "dbo.MyTable";
    		DataTable dt = BuildMyData();
    		try
    		{
    			bulkCopy.WriteToServer(dt);
    		}
    		catch (Exception ex){Console.WriteLine(ex.Message);}
    	}
    }
