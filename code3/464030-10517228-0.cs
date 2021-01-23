	public TransactedConnection GetConnection (string text)
	{
		return new TransactedConnection (_ConnectionString, text);
	}
	public class TransactedConnection : IDisposable
	{
		private readonly SQLiteCommand _Cmd;
		private readonly SQLiteConnection _Con;
		private readonly SQLiteTransaction _Tr;
		public TransactedConnection (string connection, string text)
		{
			_Cmd = new SQLiteCommand (text);
			_Con = new SQLiteConnection (connection);
			_Con.Open ();
			_Cmd.Connection = _Con;
			_Tr = _Con.BeginTransaction ();
		}
		public void Dispose ()
		{
			_Tr.Commit ();
			_Tr.Dispose ();
			_Con.Dispose ();
			_Cmd.Dispose ();
		}
		public SQLiteParameterCollection Parameters
		{
			get
			{
				return _Cmd.Parameters;
			}
		}
		public int ExecuteNonQuery ()
		{
			return _Cmd.ExecuteNonQuery ();
		}
		public object ExecuteScalar ()
		{
			return _Cmd.ExecuteScalar ();
		}
		public SQLiteDataReader ExecuteReader ()
		{
			return _Cmd.ExecuteReader ();
		}
	}
	public void Test (string match)
	{
		var text = "SELECT * FROM Data WHERE foo=@bar;";
		using (var cmd = GetConnection (text)) {
			cmd.Parameters.Add ("@bar", DbType.String).Value = match;
			using (var reader = cmd.ExecuteReader ()) {
				while (reader.Read ()) {
					Console.WriteLine (reader["foo"]);
				}
			}
		}
	}
