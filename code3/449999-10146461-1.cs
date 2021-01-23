    using ( var reader = cmd.ExecuteReader() )
    {
        // you haven't positioned yourself on a record yet.
        while (reader.Read())
        {
            return reader.GetString( reader.GetOrdinal( "Name" ) );
        }
        return string.Empty;
    }
