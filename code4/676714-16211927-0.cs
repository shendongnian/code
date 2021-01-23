    public static IEnumerable<Tuple<T>> SqlQuery<T>(this DbContext context, string sql)
    {
    	using(var connection = new SqlConnection(context.Database.Connection.ConnectionString))
    	using (var command = new SqlCommand(sql, connection))
    	{
    		var reader = command.ExecuteReader();
    		while (reader.NextResult())
    		{
    			yield return new Tuple<T>((T)reader[0]);
    		}
    	}
    }
    public static IEnumerable<Tuple<T1, T2>> SqlQuery<T1, T2>(this DbContext context, string sql)
    {
    	using (var connection = new SqlConnection(context.Database.Connection.ConnectionString))
    	using (var command = new SqlCommand(sql, connection))
    	{
    		var reader = command.ExecuteReader();
    		while (reader.NextResult())
    		{
    			yield return new Tuple<T1, T2>((T1)reader[0], (T2)reader[1]);
    		}
    	}
    }
