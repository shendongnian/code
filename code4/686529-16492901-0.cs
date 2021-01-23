    public abstract class EntityBase
    {
      public Guid Id { get; set; }
      public string Title { get; set; }
      public int Price { get; set; }
      public int Ammount { get; set; }
    }
    public class Oil : EntityBase
    {
    }
    public class Filter : EntityBase
    {
    }
