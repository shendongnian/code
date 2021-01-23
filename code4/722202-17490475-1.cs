    if !reader.IsDBNull(reader.GetOrdinal("STARTINGDATE"))
    {
        startingDate = reader.GetDateTime(reader.GetOrdinal("STARTINGDATE"));
    }
    else
    {
        startingDate = null;
    }
