    private void UpdateDataBase(char letter)
    {
        letter = char.ToUpper(letter);
        int serialPro = 0;
        string connectionString = "...";
        try
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT tblProInfo.proInfoSerialNum FROM tblProInfo ";
                using (OleDbCommand command = new OleDbCommand(sql, connection))
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    //get the last!
                    while (reader.Read())
                        serialPro = reader.GetInt32(reader.Depth);
                }
                sql = "INSERT INTO ...";
                using (OleDbCommand command2 = new OleDbCommand(sql, connection))
                {
                    command2.CommandType = CommandType.Text;
                    command2.Parameters.AddWithValue("orderAASerialPro", serialPro);
                    command2.Parameters.AddWithValue("orderAACodon1", letter);
                    command2.ExecuteNonQuery();
                }
            }
        }
        catch (Exception e)
        {
            MessageBox.Show("אירעה שגיאה ב: \n" + e.Message);
        }
    }
