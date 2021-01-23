    public List<GroupedByLength> GroupParts()
    {
      return this
        .GroupBy( o => o.Length )
        .Select( g => new GroupedByLength
          {
            Length = g.Key,
            CutParts = g.ToList(),
          }
        )
        .ToList()
      ;
    }
