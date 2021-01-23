	IList<MyBaseClass> items = new List<MyBaseClass>();
	ObjectContext oContext = ((IObjectContextAdapter)dbContext).ObjectContext;
	using (var sqlConn = new SqlConnection(dbContext.Database.Connection.ConnectionString))
	{
		SqlCommand sqlComm = new SqlCommand(){
			Connection = sqlConn,
			CommandText = "spGetMyDerivedItems",
			CommandType = CommandType.StoredProcedure
		};
		sqlConn.Open();
		using (SqlDataReader reader = command.ExecuteReader())
		{
			oContext.Translate<MyFirstDerivedClass>(reader).ToList().ForEach( x => items.Add(x));
			reader.NextResult();
			...repeat for each derived type...          
		}
	}
	return items;
