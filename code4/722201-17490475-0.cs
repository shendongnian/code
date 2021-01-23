    if reader.IsDBNull(reader.GetOrdinal("MiddleName"))
    {
        startingDate = reader.GetDateTime(reader.GetOrdinal("STARTINGDATE"));
    }
    else
    {
        startingDate = null;
    }
