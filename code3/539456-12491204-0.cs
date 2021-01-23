    var result = context.MyTable
                        .Where(x => x.Code > 15);
    if (direction == "ASC")
    {
        result = result.OrderBy(field);
    }
    else
    {
        result = result.OrderByDescending(field);
    }
    result = result.Skip(10)
                   .Take(5)
                   .ToList<MyTable>();
