    int soFar = 0;
    var grouped = data
      .GroupBy( x => ranges.FirstOrDefault( r => r <= x.Price ) )
      .OrderByDescending(g => g.Key)
      .Select(g =>
      {
        soFar += g.Count();
        return new Tuple<int, int>(g.Key, soFar)
      });
