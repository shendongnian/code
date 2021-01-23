    string search = "Cysleys Farm (by request only)";
    var query = doc.Root.Elements()
                .SingleOrDefault( x => x.Element( "StopName" ).Value == search );
    
    if (query != null)
    {
        // if the query is not null, then this will be 
        // a single node with a root of <Stop>
        string id = query.Element( "stopId" ).Value;
    }
