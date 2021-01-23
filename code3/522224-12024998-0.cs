    public static DataSet GetDatabaseObjectHistory(
        string objectType,
        string schemaName,
        string objectName,
        string msConnectionString
    )
    {
        const string sql = 
            @"SELECT
                  RowId,
                  EventTime,
                  LoginName,
                  UserName,
                  DatabaseName,
                  SchemaName,
                  ObjectName,
                  ObjectType,
                  DDLCommand
              FROM
                  Audit_Log
              WHERE
                  Audit_Log.ObjectType = @ObjectType AND
                  Audit_Log.SchemaName = @SchemaName AND
                  Audit_Log.ObjectName = @ObjectName
            ";
        using (SqlConnection con = new SqlConnection(msConnectionString))
        using (SqlCommand cmd = con.CreateCommand())
        {
            con.Open();
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@ObjectType", objectType);
            cmd.Parameters.AddWithValue("@SchemaName", schemaName);
            cmd.Parameters.AddWithValue("@ObjectName", objectName);
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                DataSet ds = new DataSet();
                da.Fill(ds);
                ds.Tables[0].TableName = "Object History";
                return ds;
            }
        }
    }
