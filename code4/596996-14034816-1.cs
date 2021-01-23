    if (info.Trim() != String.Empty)
    {
        string[] words = info.Split(',');
        if (words.Length == 6)
        {
            name = words[0].Trim();
            date = words[1].Trim();
            place = words[2];
            blood = words[3];
            num = words[4];
            address = words[5];
        }
        string cmdText = "INSERT INTO patients (" +
           "firstlastname, birthdate, birthplace, bloodtype, telnum, address) " +
           "VALUES (?,?,?,?,?,?)";
        using (OleDbConnection cn = GetConnection())
        {
            using (OleDbCommand cmd = new OleDbCommand(cmdText, cn))
            {
                cmd.Parameters.AddWithValue("name", name);
                cmd.Parameters.AddWithValue("date", date);
                cmd.Parameters.AddWithValue("place", place);
                cmd.Parameters.AddWithValue("blood", blood);
                cmd.Parameters.AddWithValue("num", num);
                cmd.Parameters.AddWithValue("address", address);
                cmd.ExecuteNonQuery();
            }
        }
    }
