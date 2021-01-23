    SqlCommand Command = new SqlCommand(Query, Connection);
    for (int i=0; i<TextBoxes.Count; i++)
    {
        Command.Parameters.AddWithValue("@col" + i, TextBoxes[i].Text);
    }
    Connection.Open()
    Command.ExecuteNonQuery();
    Connection.Close()
