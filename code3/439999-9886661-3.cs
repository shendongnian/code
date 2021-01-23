    public interface IRenderable : IComparable<IRenderable>
    {
        int Id { get; }
    }
    
    public class SomeRenderable : IRenderable
    {
       public int CompareTo(IRenderable other)
       {
          if (other is SomeRenderable)
             return 0;
          if (other is OtherRenderableType)
             return 1;   
       }
    }
