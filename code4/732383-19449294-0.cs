    public class DifferenceConverter<T> : ITypeConverter<T, T>
    {
      public T Convert(ResolutionContext context)
      {
      // Code to check each property to see if different, could be done with
      // Reflection or by writing some Dynamic IL.
      // Personally I would use Reflection to generate (then cache) an Expression tree  
      // to compare each object at native speeds..
    
      return differenceObject;
      }
    }
