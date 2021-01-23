    string connStr = "User Id=xxx;Password=yyy;Data Source=my11gDb;";
    using (OracleConnection con = new OracleConnection(connStr))
    {
    	string s = "ALTER TABLE T1 ADD (added_col VARCHAR2(10))";
    	using (OracleCommand cmd = new OracleCommand(s, con))
    	{
    		con.Open();
    		cmd.ExecuteNonQuery();
    
    		string s2 = "select column_name from all_tab_columns where table_name = 'T1'";
    		//con.FlushCache(); // doesn't seem to matter, works with or without
    
    		using (OracleCommand cmd2 = new OracleCommand(s2, con))
    		{
    			OracleDataReader rdr = cmd2.ExecuteReader();
    
    			for (int i = 0; rdr.Read(); i++)
    			{
    				Console.WriteLine("Column {0} => {1}",i+1,rdr.GetString(0));
    			}
    			rdr.Close();
    		}
    	}
    }
