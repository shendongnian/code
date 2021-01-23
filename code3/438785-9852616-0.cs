    var query = result.Partials.Where(o => o.IsPositve);
    if (query.Any())
    {
         sum = query.Sum(o => o.Result);
    }
