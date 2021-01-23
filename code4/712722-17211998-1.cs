    string cmdText = "DELETE from CURSE WHERE ID_CURSA  = :ID"
    using(OracleConnection conn = new OracleConnection(provider))
    using(OracleCommand cmd = new OracleCommand(cmdText, conn))
    {
         conn.Open();
         cmd.Parameters.AddWithValue("ID", textBox1.Text);
         cmd.ExecuteNonQuery();
    }
