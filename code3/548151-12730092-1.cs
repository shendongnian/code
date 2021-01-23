    public T GetScalarValue<T>(string sql)
    {
        T t = default(T);
    	
        try {
            SqlConnection conn = new SqlConnection("MY_SQL_SERVER_CONNECTION_STRING");
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            
    		var result = cmd.ExecuteScalar();
    		
    		if (result == null) {
    			return t;
    		}
    		
    		t = (T)result;
        }
        catch (Exception ex) {
            return t;
        }
        finally{
            if(conn.State == ConnectionState.Open)
                conn.Close();
        }
    	
        return t;
    }
