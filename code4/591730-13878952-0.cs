    command.CommandText = "SELECT * FROM Student WHERE GPA > 2";
    using(var reader = command.ExecuteReader())
    {
        while (reader.Read())
        {
            // assuming that there's a column with name: StudentName
            listBox2.Items.Add(reader.GetString(reader.GetOrdinal("StudentName")));
        }
    }
