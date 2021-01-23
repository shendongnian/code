    int i = -1;
    while (reader.Read())
    {
        users[i++] =  new  {
        userid= reader.GetString(0),
        group = reader.GetString(1),
        subgroup = reader.GetString(2),
        };
    }
