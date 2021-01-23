    detailsList = details.OrderBy(item => item.Order).ThenBy(item => item.Title)
        .Select((t, index) => new AdminDetail()
        {
            PartitionKey = t.PartitionKey,
            RowKey = t.RowKey,
            Title = t.Title,
            Status = t.Status,
            Type = t.Type,
            Level = t.Level,
            Order = t.Order,
            Row = index + 1
        }).ToList();
