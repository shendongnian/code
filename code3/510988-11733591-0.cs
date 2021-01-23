    List<MyEntity> source1 = ...;
    List<MyEntity> source2 = ...;
    IEnumerable<MyEntity> source3 = ...;
    
    var mergedList = (from item in source1.Contact(source2).Concat(source3)
                      group item by item.Name into g
                      select new MyEntity { Name = g.Key, Value = g.Sum(e => e.Value) })
                      .ToList();
