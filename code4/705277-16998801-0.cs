	class Connection
	{
		// internal details of the connection; should not be public.
		protected object _client;
		
		// base class constructor
		public Connection(object client) { _client = client; }
		// copying constructor
		public Connection(Connection other) : this(other._client) { }
	}
	class AuthenticatedConnection : Connection
	{
		// broken constructor?
		public AuthenticatedConnection(string token, Connection connection)
			: base(connection)
		{
			// use token etc
		}
	}
