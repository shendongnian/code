    string dataSource = "Database.s3db";
    using (SQLiteConnection connection = new SQLiteConnection())
    {
        connection.ConnectionString = "Data Source=" + dataSource;
        connection.Open();
        using (SQLiteCommand command = new SQLiteCommand(connection))
        {
            command.CommandText =
                "update Example set Info = :info, Text = :text where ID=:id";
            command.Parameters.Add("info", DbType.String).Value = textBox2.Text; 
            command.Parameters.Add("text", DbType.String).Value = textBox3.Text; 
            command.Parameters.Add("id", DbType.String).Value = textBox1.Text; 
            command.ExecuteNonQuery();
        }
    }
