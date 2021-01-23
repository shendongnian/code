    public class Event
    {
      public string Name { get; set; }
      public string Description { get; set; }
      public IList<Result> Results { get; set; }
    }
    
    public class Result
    {
      public Competitor Competitor { get; set; }
      public TimeSpan ResultTime { get; set; }
    }
    
    public class Competitor
    { ... }
