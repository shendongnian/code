    string dataSource = "Database.s3db";
    using (SQLiteConnection connection = new SQLiteConnection())
    {
        connection.ConnectionString = "Data Source=" + dataSource;
        connection.Open();
        using (SQLiteCommand command = new SQLiteCommand(connection))
        {
            command.CommandText =
                "update Example set Info = :info, Text = :text where ID=:id";
            command.Parameters.Add("info", SQLiteType.Text).Value = textBox2.Text; 
            command.Parameters.Add("text", SQLiteType.Text).Value = textBox3.Text; 
            command.Parameters.Add("id", SQLiteType.Text).Value = textBox1.Text; 
            command.ExecuteNonQuery();
        }
    }
