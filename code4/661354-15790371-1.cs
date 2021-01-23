    public static SqlCeConnection OpenDefaultConnection()
    {
        SqlCeConnection conn = new SqlCeConnection(DbConnection.compact);
        conn.Open();
        return conn;
    }
