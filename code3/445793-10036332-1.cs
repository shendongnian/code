			StringBuilder query = new StringBuilder();
			query.Append("CREATE TABLE ");
			query.Append(tableName);
			query.Append(" ( ");
			for (int i = 0; i < columnNames.Length; i++)
			{
				query.Append(columnNames[i]);
				query.Append(" ");
				query.Append(columnTypes[i]);
				query.Append(", ");
			}
			if (columnNames.Length > 1) { query.Length -= 2; }	//Remove trailing ", "
			query.Append(")");
			SqlCommand sqlQuery = new SqlCommand(query.ToString(), sqlConn);
			SqlDataReader reader = sqlQuery.ExecuteReader();
