    using (SqlConnection sqlcon  = new SqlConnection(
    		"Data Source=ERHANEMREEROGLU/SQLEXPRESS;Initial Catalog=KET;Integrated Security=True"))
    	    {
    		c.Open();
    		using (SqlDataAdapter a = new SqlDataAdapter("SELECT * FROM Login", sqlcon ))
    		{
    		    DataTable t = new DataTable();
    		    a.Fill(t);
    		}
    	    }
