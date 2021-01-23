    context.Games.Select(g => new
    {
        Field = queryable1.Where(q => g.IsX)
                   .Concat(queryable2.Where(q => !g.IsX))
    });
