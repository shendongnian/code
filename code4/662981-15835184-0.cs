    public static DataSet ExecuteStoredProcedure(ObjectContext db, 
                                                 string storedProcedureName, 
                                                 IEnumerable<SqlParameter> parameters)
    {
        var connectionString = 
            ((EntityConnection)db.Connection).StoreConnection.ConnectionString;
        var ds = new DataSet();
        using (var conn = new SqlConnection(connectionString))
        {
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = storedProcedureName;
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (var parameter in parameters)
                {
                    cmd.Parameters.Add(parameter);
                }
                using (var adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(ds);
                }
            }
        }
        return ds;
    }
