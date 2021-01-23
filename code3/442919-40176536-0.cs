	private class SqlLogger : EmptyInterceptor
	{
		private const string Select = "SELECT";
		private const int SelectLen = 6;
		private const string Hint = " /*+ dynamic_sampling(0) */";
		private const char Param = '?';
		public override SqlString OnPrepareStatement(SqlString sql)
		{
			var s = sql.ToString().ToUpper();
			var start = s.IndexOf(Select, StringComparison.Ordinal);
			if (start != -1)
				s = s.Insert(SelectLen, Hint);
			var builder = new SqlStringBuilder();
			var parts = s.Split(Param);
			for (var i = 0; i < parts.Length - 1; i++)
			{
				builder.Add(parts[i]);
				builder.AddParameter();
			}
			builder.Add(parts.Last());
			sql = builder.ToSqlString();
						   
			return sql;
		}
	}
