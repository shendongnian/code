      private void DoSomething(MySqlConnection connection)
    {            
    using (var command = connection.CreateCommand())
            {
                command.CommandText = ("Select Room_name from firstfloor where Room_no=(?room)");
                command.Parameters.AddWithValue("?room", b);
                command.ExecuteNonQuery();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    button2.Text = reader["Room_name"].ToString();
                }
            }
        }
