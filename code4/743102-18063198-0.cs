    private DataTable GetSPResult()
    {
    	DataTable ResultsTable = new DataTable();
    
    	SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
    
    	try
    	{
    		SqlCommand cmd = new SqlCommand("yourStorePorcedure", conn);
    		cmd.CommandType = CommandType.StoredProcedure;
    		cmd.Parameters.AddWithValue("@id", 1);
    		SqlDataAdapter adapter = new SqlDataAdapter(cmd);
    		adapter.Fill(ResultsTable);
    	}
    
    	catch (Exception ex)
    	{
    		Response.Write(ex.ToString());
    	}
    	finally
    	{
    		if (conn != null)
    		{
    			conn.Close();
    		}
    	}
    
    	return ResultsTable;
    }
