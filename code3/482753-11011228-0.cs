    .OrderByDescending(item => item.RowKey.Substring(0, 4))
    .ThenBy(item => item.ShortTitle)
    .Select((t, index) => new City.Grid()
           {
               PartitionKey = t.PartitionKey,
               RowKey = t.RowKey,
               Row = index + 1,
               ShortTitle = t.ShortTitle,
           }) 
