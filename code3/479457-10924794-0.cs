    ...
    SqlDataReader reader = command.ExecuteReader();
    if (reader.Read())
    {
        string[] tokens = reader.GetString(0).Split(';');
        for(int i = 0; i < tokens.Length; i++)
        {
            textBoxes[i].Text = tokens[i];
        }
    }
    ...
