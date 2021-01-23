    while (reader.Read()) {
        dtl = new DetailsClass((reader.GetInt32(reader.GetOrdinal("MEMBERSHIPGEN"))),
    
        // here you are checking null for email
        reader.IsDBNull(1) ? null : reader.GetString(reader.GetOrdinal("EMAIL")),
    
        // here you are not checking null for startingdate ?
        reader.GetDateTime(reader.GetOrdinal("STARTINGDATE")));
        details.Add(dtl);
    }
                        
