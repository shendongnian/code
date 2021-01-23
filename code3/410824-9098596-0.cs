    DataTable GetTable()
      {
        try
    	{
    		string query = "select * from items";
    		MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
    		DataSet DS = new DataSet();
    		adapter.Fill(DS);
    		return DS.Tables[0];
    	}
    }
