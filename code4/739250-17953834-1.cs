    using(OleDbConnection conn = new System.Data.OleDb.OleDbConnection(connString))
    {
    conn.Open();
    string query= "DELETE FROM Questions WHERE QID = @pID";
    OleDbCommand comamnd = new OleDbCommand(query, conn);
    comamnd.Parameters.Add("@pID",OleDbType.Integer).Value = j;
    comamnd.CommandType = CommandType.Text;
    command.ExecuteNonQuery();
    conn.Close();
    }
