    string appName = TextBox1.Text;
    string commandText = "CREATE DATABASE @DBName";
    using (MySqlCommand cmd = new MySqlCommand(commandText, connection))
    {
        cmd.Parameters.Add("@TableName", System.Data.SqlDbType.NVarChar, 50);
        cmd.Parameters["@TableName"].Value = appName;
        cmd.Connection.Open();
        cmd.ExecuteNonQuery();
    }
