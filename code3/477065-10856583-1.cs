    public interface Root {}
    public class RootItem<T> : Root
    {
      public string Name { get; set; }
      public List<T> Children {get; set; }
    }
