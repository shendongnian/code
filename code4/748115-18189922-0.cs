    using System.Data.SqlServerCe;
    private SqlCeConnection InitializeDatabase()
    {
        string connectionString = CreateDatabase();
        SqlCeConnection conn = new SqlCeConnection(connectionString);
        conn.Open();
        CreateTable(conn);
        return conn;
    }
    private string CreateDatabase()
    {
        string dbPath = String.Format("{0}scanner.sdf", _rootPath);
        if (File.Exists(dbPath))
            File.Delete(dbPath);
        string connectionString = String.Format("DataSource=\"{0}\";Max Database Size=3000;", dbPath);
        SqlCeEngine en = new SqlCeEngine(connectionString);
        en.CreateDatabase();
        en.Dispose();
        return connectionString;
    }
    private void CreateTable(SqlCeConnection conn)
    {
        using (SqlCeCommand comm = new SqlCeCommand())
        {
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "CREATE TABLE gnis ([Id] [int] IDENTITY(1,1) PRIMARY KEY, [Name] [nvarchar](110) NOT NULL, [Geometry] [varbinary](429) NOT NULL)";
            comm.ExecuteNonQuery();
        }
    }
    private void CreateTableIndex(SqlCeConnection conn)
    {
        using (SqlCeCommand comm = new SqlCeCommand())
        {
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "CREATE INDEX IXgnis ON gnis ([Name]);";
            comm.ExecuteNonQuery();
        }
    }
    private void WriteFeature(SqlCeConnection conn, string name, MultiPoint multiPoint)
    {
        byte[] wkb = WkbWriter.WriteWkb(multiPoint);
        using (SqlCeCommand comm = new SqlCeCommand())
        {
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "INSERT INTO gnis ([Name], [Geometry])  VALUES (@a, @b)";
            comm.Parameters.AddWithValue("@a", name);
            comm.Parameters.AddWithValue("@b", wkb);
            comm.ExecuteNonQuery();
        }
    }
