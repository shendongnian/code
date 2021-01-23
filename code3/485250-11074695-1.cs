    public class ResultList<T> : IEnumerable<T>, ICloneable where T : ICloneable
    {
      public List<T> Results { get; set; }
      public decimal CenterLatitude { get; set; }
      public decimal CenterLongitude { get; set; }
      public object Clone()
      {
        var list = new ResultList<T>
                     {
                       CenterLatitude = CenterLatitude,
                       CenterLongitude = CenterLongitude,
                       Results = Results.Select(x => x.Clone()).Cast<T>().ToList()
                     };
        return list;
      }
    }
