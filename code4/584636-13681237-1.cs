    public MyStuff GetStuff(string paramValue)
    {
    	using (OracleCommand command = connection.CreateCommand())
    	{
    		command.CommandText = "select XXX from YY where param = ? ";
    		command.Parameters.Add(":param ", OracleDbType.Varchar2).Value = paramValue;
    		using (IDataReader reader = command.ExecuteReader())
    		{
    			while (reader.Read())
    			{
    			...
    			}
    		}
    		return stuff;
    	}
    }
