    // Work out the values beforehand
    string name = getPlayerName(Tibia.Handle, 
                    (BattleList_Start + Base + (BattleList_Step * playerIndex) + 4));
    int level = ReadInt32(LvlAdr + Base, 4, Tibia.Handle);
    int experience = ReadInt32(XpAdr + Base, 4, Tibia.Handle);
    // Now do the database operations
    string sql = @"INSERT INTO player (date, name, level, experience) 
                   VALUES (@Date, @Name, @Level, @Experience)";
    using (var conn = new MySqlConnection(...))
    {
        conn.Open();
        using (var cmd = new MySqlCommand(sql, conn))
        {
            cmd.Parameters.Add("@Date", MySqlDbType.Date).Value = DateTime.Today;
            cmd.Parameters.Add("@Name", MySqlDbType.VarChar).Value = name;
            cmd.Parameters.Add("@Level", MySqlDbType.Int32).Value = level;
            cmd.Parameters.Add("@Experience", MySqlDbType.Int32).Value = experience;
            int rows = cmd.ExecuteNonQuery();
            // TODO: Validation of result (e.g. that 1 row was inserted)
        }
    }
