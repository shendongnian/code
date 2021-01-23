    .OrderByDescending(item => item.RowKey)
    .ThenByDescending(item => item.ShortTitle)
     .Select((t, index) => new City.Grid()
               {
                   PartitionKey = t.PartitionKey,
                   RowKey = t.RowKey,
                   Row = index + 1,
                   ShortTitle = t.ShortTitle,
    
               })
