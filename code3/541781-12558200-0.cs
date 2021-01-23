    public static string DELETE_PDT(String rowid)
    {
        using (SqlConnection con = new SqlConnection())
    	{
    		con.ConnectionString = ConfigurationManager.ConnectionStrings["WMS"].ConnectionString;
    		using (SqlCommand cmd = new SqlCommand("sp_DELETE_PDT", con))
    		{
    			cmd.CommandType = CommandType.StoredProcedure;
    			cmd.Parameters.Add("@rowid", SqlDbType.Int).Value = rowid;
    			try
    			{
    				con.Open();
    				cmd.ExecuteNonQuery();
    				return "Record has been deleted";
    			}
    			catch (Exception ex)
    			{
    				return "Error while deleting record. Please contact your System Administrator";
    			}
    		}
    	}
    }
