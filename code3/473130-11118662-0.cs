    string const query = "SELECT * FROM LocalTableName";
    using (DbCommand sql =_MySQLConnection.CreateCommand()){
        sql.CommandText = query;
        using (DbDataReader row = sql.ExecuteReader()){
            // the data is sstored in row now upload to remote
            using (DbCommand sql_remote = _MySQLRemote.CreateCommand()){
                sql_remote.CommandText = "INSERT INTO RemoteTableName SET field1 = @p_field1";
                sql.Parameters.Add("@p_field1", row["field1"].toString());
                sql.ExecuteNonQuery();
                sql.Parameters.Clear();
            }
        }
    }
