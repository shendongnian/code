    Entry entryAlias = null;
    
    var q = session.QueryOver<Comment>()
        .JoinAlias(x => x.Entry, () => entryAlias)
    	.Where(() => entryAlias.Author == username);
    	
    var totalFuture = q.ToRowCountQuery().FutureValue<int>(); //ToRowcountQuery clones the query, we can reuse it for results
    
    var resultsFuture = q
        //.Fetch(x => x.Entry).Eager() //already joined
        .OrderBy(x => x.Posted).Desc()
        .Skip(skip)
        .Take(take)
    	.Future<Comment>();
    	
    var results = resultsFuture.ToList(); //both future queries are executed in the same batch 
    var total = totalFuture.Value;
