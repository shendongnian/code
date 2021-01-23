    var queryTask = Task.Factory.FromAsync<IEnumerable<TResult>>(query.BeginExecute(null, null), (asResult) =>
    {
       var result = query.EndExecute(asResult).ToList();
       return result;
    });
