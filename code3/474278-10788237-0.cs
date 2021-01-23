    using (var conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["Con2"].ConnectionString))
    {
        conn.Open();
    	using (var cmd = conn.CreateCommand())
    	{
    		cmd.CommandText ="SELECT COUNT(*) FROM " + ConfigSettings.ReadSetting("main_base");
    		int nRows = Convert.ToInt32(cmd.ExecuteScalar());
    		if (nRows > 0)
            {
    			using (var conn2 = new MySqlConnection(ConfigurationManager.ConnectionStrings["Con1"].ConnectionString))
    			{
    				conn2.Open();
    				using (var cmd2 = conn2.CreateCommand())
    				{
    					cmd2.CommandText ="INSERT INTO temp_data SELECT * FROM data";
    					cmd2.ExecuteScalar();
    				}
    			}
    		}
    	}
    }
