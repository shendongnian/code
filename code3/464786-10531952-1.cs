    var query = _cityRepository.GetAll(
                                   u => u.PartitionKey == pk & 
                                   u.RowKey.CompareTo(lowerBound) >= 0 & 
                                   u.RowKey.CompareTo(upperBound) < 0)
                    .OrderBy(item => item.Modified)
                    .Select((t, index) => new City.Grid()
                    {
                        PartitionKey = t.PartitionKey,
                        RowKey = t.RowKey,
                        Row = index + 1,
                        ShortTitle = t.ShortTitle,
                        Created = t.Created,
                        Modified = t.Modified,
                        ModifiedBy = t.ModifiedBy
                    })
                    .ToList();
