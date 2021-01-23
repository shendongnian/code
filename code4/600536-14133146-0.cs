    string query = @"UPDATE bartran SET aNumberCounter = ? WHERE id = ?;";
    OdbcCommand cmd=new OdbcCommand(query,connection);
    cmd.Parameters.Add("?",OdbcType.Int);
    cmd.Parameters.Add("?",OdbcType.Int);
    connection.Open();
    for (int i = 0; i < dsData.Tables["data"].Rows.Count; i++)
     {
      ...
      cmd.Parameters[0].Value=aNumberCounter;
      cmd.Parameters[1].Value=id;
      cmd.ExecuteNonQuery();
      }
    connection.Close();
