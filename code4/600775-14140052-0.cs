    string updateSql = @"
        UPDATE ROOMS SET
            Counter = Counter + 1,
            Occupants = Occupants + ',' + @newUser
        WHERE
            Room = @Room";
    using(var con = new SqlConnection(connectionString))
    using (var updateCommand = new SqlCommand(updateSql, con))
    {
        updateCommand.Parameters.AddWithValue("@newUser", user);
        updateCommand.Parameters.AddWithValue("@Room", room);
        con.Open();
        updateCommand.ExecuteNonQuery();
    }
