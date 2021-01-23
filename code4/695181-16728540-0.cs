    DataTable dt1 = new DataTable();
    DataTable dt2 = new DataTable();
    DataTable dtResult = new DataTable();
    string query = "SELECT * FROM BOOKS1 UNION SELECT * FROM BOOKS2 UNION SELECT * FROM BOOKS3";
    
    using (SqlConnection con = new SqlConnection(strConnect))
    {
    	using (SqlCommand command = new SqlCommand(query, con))
    	{
    		using (SqlDataReader dr = command.ExecuteReader())
    		{
    			dt1 = new DataTable();
    			dt1.Load(dr);
    		}
    	}
    }
    
    using (SqlConnection con = new SqlConnection(strConnect2))
    {
    	using (SqlCommand command = new SqlCommand(query, con))
    	{
    		using (SqlDataReader dr = command.ExecuteReader())
    		{
    			dt2 = new DataTable();
    			dt2.Load(dr);
    		}
    	}
    }
    
    dtResult = d1.Clone();
    dtResult.Merge(dt2, false);
