    public static class DbCommandExtensions {
		public static void ExecuteMultipleNonQuery(this IDbCommand dbCommand)
		{
			var sqlStatementArray = dbCommand.CommandText.Split(new string[] {";"}, StringSplitOptions.RemoveEmptyEntries);
			foreach (string sqlStatement in sqlStatementArray)
			{
				dbCommand.CommandText = sqlStatement;
				dbCommand.ExecuteNonQuery();
			}
		}
	}
