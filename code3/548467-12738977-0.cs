	public class Class1
	{
		private static SqlConnection GetSqlConnection() { /* unchanged */ }
		
		public static void UseSqlConnection(Action<SqlConnection> action)
		{
			using (var connection = Class1.GetSqlConnection())
			{
				action(connection);
			}
		}
	}
