    var ordered = from item in _table
                  orderby item.Order, item.Title
                  select item;
    var details = ordered.Select((t, index) => new AdminDetail
                                 {
                                     PartitionKey = t.PartitionKey,
                                     RowKey = t.RowKey,
                                     Title = t.Title,
                                     Status = t.Status,
                                     Type = t.Type,
                                     Level = t.Level,
                                     Order = t.Order,
                                     Row = index + 1
                                 })
                          .ToList();
