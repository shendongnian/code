    public MyModel GetModel(IQueryable<Something> query, Func<Something, string> sort, 
       int page, int PageSize)
    {
       Func<Something, string> actualSort = sort ?? (o => o.AddedDate);
       ...
       viewModel.Something = query.OrderByDescending(actualSort)
              .Skip((page - 1) * pageSize).Take(pageSize).ToList();
       ...
    }
