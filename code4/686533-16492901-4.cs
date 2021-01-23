    public abstract class OilFilterBase
    {
      public Guid Id { get; set; }
      public string Title { get; set; }
      public int Price { get; set; }
      public int Amount { get; set; }
    }
    public class Oil : OilFilterBase
    {
    }
    public class Filter : OilFilterBase
    {
    }
