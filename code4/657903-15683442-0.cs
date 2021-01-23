        StreamWriter Writer = new StreamWriter("Filename");
        string SQL = "select Item from Table where ID in (1, 2, 3)";
        SqlCommand Command = new SqlCommand(SQL, Con);
        SqlDataReader Reader = Command.ExecuteReader();
        while (Reader.Read())
            Writer.WriteLine(Reader["Item"].ToString());
        Reader.Close();
        Writer.Close();
