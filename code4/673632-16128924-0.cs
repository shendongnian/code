    OleDbConnection My_Connection = new OleDbConnection("Provider=Microsoft.Jet...
    My_Connection.Open();
    string sql = " UPDATE Rooms SET [Room Status] = 'Taken', [Available] = 0"+
                 " WHERE [RoomNumber] = ?";
    OleDbCommand My_Command = new OleDbCommand(sql, My_Connection);
    My_Command.Parameters.AddWithValue("RoomNumber",  Convert.ToInt32(textBox5.Text));
    My_Command.ExecuteNonQuery();
    My_Connection.Close();
