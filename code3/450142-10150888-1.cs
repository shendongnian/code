    while (reader.Read())
    {
        if (reader.IsStartElement())
        {
           if (reader.Name == "id")
           {
               id = reader.ReadString();
           }
    ...
    }
