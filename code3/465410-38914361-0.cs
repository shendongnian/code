    var sqlCmd = new SqlCommand(sql, context.Database.Connection as SqlConnection);
    sqlCmd.Parameters.Add(idParam);
    sqlCmd.CommandTimeout = 90;
    if (sqlCmd.Connection.State == System.Data.ConnectionState.Closed)
    {
        sqlCmd.Connection.Open();
    }
    sqlCmd.ExecuteNonQuery();
    sqlCmd.Connection.Close();
