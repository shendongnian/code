    CombinedQuery query = new CombinedQuery();
    
    //apply other filters here to query if need be
    
    //and country filter by creating a new clause (combinedquery) and "ORing" within it (QueryOccurance.Should)
    CombinedQuery query3 = new  CombinedQuery();
    //here you would actually iterate over your country list
    query3.Add(new FieldQuery("countries", country1GUID), QueryOccurance.Should);
    query3.Add(new FieldQuery("countries", country2GUID), QueryOccurance.Should);
    query.Add(query3, QueryOccurance.Must);
