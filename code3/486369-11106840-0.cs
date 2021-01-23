    var groups = _repository.GetAll()
      .GroupBy(x => x.RowKey.Substring(0, 2))
      .Select(x => new 
      { 
        RowKey = x.Key, // + "00"
        Count = x.Count(),
        SubItems = x.GroupBy(y => y.RowKey).Select(z => new { RowKey = z.Key, Count = z.Count() })
      });
    foreach(var outerGroup in groups)
    {
      Console.WriteLine(outerGroup.RowKey + " " + outerGroup.Count);
      foreach(var innerGroup in outerGroup.SubItems)
      {
        Console.WriteLine(innerGroup.RowKey + " " + innerGroup.Count);
      }
    }
