    sqlQuery = "SELECT [ID] from [users] WHERE CallerName=@CallerName";
    OleDbConnection conn = new OleDbConnection(connectionString);
    conn.Open();
    cmd = new OleDbCommand(sqlQuery, conn);
    cmd.CommandText = sqlQuery;
    cmd.Parameters.Add("@CallerName", OleDbType.VarChar).Value = labelProblemDate.Text.Trim();
    cmd.Parameters["@CallerName"].Value = name;
    cmd.ExecuteNonQuery();
    conn.Close();
