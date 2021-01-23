	class Wrapper : IDisposable
	{
		public OleDbDataReader Reader { get { return reader; } }
		private OleDbConnection connection;
		
		public Wrapper(OleDbConnection connection, string QueryStr)
		{ 
			this.connection = connection; 
			OleDbCommand cmd = new OleDbCommand(QueryStr, connection);
			OleDbDataReader dr = cmd.ExecuteReader();
		}
		
		public void Dispose()
		{
			reader.Dispose();
			connection.Dispose();
		}
	}
	
	class dbFunctions
	{
		public static OleDbDataReader QueryString(string QueryStr)
		{
			OleDbConnection con = new OleDbConnection(GlobalVar.strAccessConn);
			con.Open();
			return new Wrapper(con, QueryStr);
		}
	}
