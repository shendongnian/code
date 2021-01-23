    string connStr = "connection String here";
    string val = "xxx'xxx";
    string query = "INSERT INTO tableName (colName) VALUES (:val)";
    using(NpgsqlConnection conn = new NpgsqlConnection(connStr))
    {
    	using(NpgsqlCommand comm = new NpgsqlCommand())
    	{
    		comm.Connection = conn;
    		comm.CommandText = query;
    		NpgsqlParameter p = new NpgsqlParameter("val", NpgsqlDbType.Text);
    		p.value = val;
    		comm.Parameters.Add(p);
    		try
    		{
    			conn.Open();
    			comm.ExecuteNonQuery();
    		}
    		catch(NpgsqlException e)
    		{
    			// do something with
    			// e.ToString();
    		}
    	}
    }
