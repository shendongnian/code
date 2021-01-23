	private void SetLimit(SqliteConnection conn, int newLimit)
	{
	   object sqlVar = conn.GetType().GetProperty("_sql", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(conn);
	   IntPtr dbHandle = (IntPtr) sqlVar.GetType().GetProperty("handle", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(sqlVar);
	   sqlite3_limit(dbHandle, 4, newLimit);
	}
