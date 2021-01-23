    while (reader.Read()) {
    
        dtl = new DetailsClass();
    
        dtl.membershipgen = reader.IsDBNull(reader.GetOrdinal("MEMBERSHIPGEN")) ? null : reader.GetInt32(reader.GetOrdinal("MEMBERSHIPGEN"));
        dtl.email = reader.IsDBNull(reader.GetOrdinal("EMAIL")) ? null : reader.GetString(reader.GetOrdinal("EMAIL")),
        dtl.startingdate = reader.IsDBNull(reader.GetOrdinal("STARTINGDATE")) ? null : reader.GetDateTime(reader.GetOrdinal("STARTINGDATE")));
    
        details.Add(dtl);
    }
