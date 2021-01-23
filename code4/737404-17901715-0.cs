    query
        .Select(item => new
        {
            ID = item.ID,
            Name = item.Name,
            Status = item.Statuses.Name
        })
        .ToArray()
        .Select(item => new MyClassFormat
        {
            ID = item.ID,
            Name = item.Name,
            Status = item.Status
        });
