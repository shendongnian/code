    var queryWithVince = query.Select(r = new 
                        { 
                            FirstName = r.FirstName, 
                            LastName = r.LastName
                        })
        .Concat( new []
            {
                new { FirstName = "Vince", LastName = "Vaughn" }
            }
        .OrderBy(p => p.FirstName);
