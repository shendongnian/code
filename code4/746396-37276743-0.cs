        string db = null;
        string table = null;
        
        DateTime dateTime = DateTime.Now.Date;
        using (var con = new SqlCeConnection(connStr))
        {
            using (
                var cmd =
                    new SqlCeCommand(
                        "INSERT INTO " + table + "(Id, Name, Zone, Map, State, Type, X, Y, Z, Create_Date, Update_Date) " +
                        "VALUES (@Id, @Name, @Zone, @Map, @State, @Type, @X, @Y, @Z, @Create_Date, @Update_Date)", con))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Zone", zone);
                cmd.Parameters.AddWithValue("@Map", map);
                cmd.Parameters.AddWithValue("@State", state);
                cmd.Parameters.AddWithValue("@Type", type);
                cmd.Parameters.AddWithValue("@X", x);
                cmd.Parameters.AddWithValue("@Y", y);
                cmd.Parameters.AddWithValue("@Z", z);
                cmd.Parameters.AddWithValue("@Create_Date", dateTime);
                cmd.Parameters.AddWithValue("@Update_Date", dateTime);
                con.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    BotControl.StopBot();
                }
            }
            cmd.Parameters.Clear();
            cmd.Dispose();
            con.Close();
            con.Dispose();
        }
   }
