    public interface IRenderable : IComparable<IRenderable>
    {
        int Id { get; }
    }
    
    public class SomeRenderable : IRenderable
    {
       public int CompareTo(IRenderable other)
       {
          if (other is SomeRenderable)
             return Id.CompareTo(other.Id);
    
          return -1;  // Strict ordering compared to other types.
       }
    }
