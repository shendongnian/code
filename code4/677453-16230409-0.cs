	public int insert(IDictionary<string, object> inserts, String table)
	{
		string query = "INSERT INTO " + table + " ";
		List<SqlParameter> parameters = new List<SqlParameter>();
		string camposItems = "(";
		string valoresItems = "(";
		foreach(KeyValuePair<string, object> pair in inserts)
		{
			if (!camposItems.EndsWith("("))
			{
				camposItems += ", ";
				valoresItems += ", ";
			}
			camposItems += pair.Key;
			valoresItems += pair.Key;
			SqlParameter parameter = new SqlParameter("@" + pair.Key, pair.Value);
			parameters.Add(parameter);
		}
		camposItems += ")";
		valoresItems += ")";
		query += camposItems + " VALUES " + valoresItems;
		using(SqlConnection conn = new SqlConnection( /*Properties.Settings.Default.dbConnectionString*/null))
		using(SqlCommand cmdIns = new SqlCommand(query, conn))
		{
			cmdIns.Parameters.AddRange(parameters.ToArray());
			cmdIns.Connection.Open();
			return cmdIns.ExecuteNonQuery();
		}
	}
