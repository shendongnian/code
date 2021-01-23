    if (reader.HasRows)
    {
        reader.Read();
        if (!reader.IsDBNull(0))
        {
            returnval = reader.GetInt32(0);
        }
    }
 
