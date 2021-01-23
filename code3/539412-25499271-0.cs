    // The ctor for `DbConnection`.
	private MyApplicationDataContext(DbConnection conn) : base(conn, true) {}
	public static MyApplicationDataContext CreateInstance()
	{
	    var directory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
	    var path = Path.Combine(directory, @"ApplicationName\MyDatabase.sdf");
	    
        // Connection string builder for `Sql ce`
	    SqlCeConnectionStringBuilder sb = new SqlCeConnectionStringBuilder();
	    sb.DataSource = path;
        // DbConnection for `Sql ce`
	    SqlCeConnection dbConn = new SqlCeConnection(sb.ToString());
	    return new MyApplicationDataContext(dbConn);
	}
