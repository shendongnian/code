    IList<SampleClient> mergedList = firstQuery.Concat(secondQuery)
        .ToLookup(x => x.ClientId)
        .Select(x => x.Aggregate((query1, query2) => 
                new SampleClient() { 
                        ClientId = query1.ClientId, 
                        JobName = query1.JobName,
                        Version = query2.Version 
                    }
                )
        ).ToList();
