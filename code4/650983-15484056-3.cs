    public static class Extensions
    {
    	public static DataSet ExecuteDataSet(this SqlCommand command)
    	{
    	    using (SqlDataAdapter da = new SqlDataAdapter(command)) {
    		DataSet ds = new DataSet();
    
    		// Fill the DataSet using default values for DataTable names, etc
    		da.Fill(ds);
    
    		return ds;
    		}
    	}
    }
