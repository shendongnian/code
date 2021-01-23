    public class BaseClass
    {
      private static readonly Dictionary<int, int> addResults = new Dictionary<int, int>();
      
      static BaseClass()
      {
        addResults.Add(CreateKey(typeof(ChildA), typeof(ChildA)), 1);
        addResults.Add(CreateKey(typeof(ChildA), typeof(ChildB)), 2);
        addResults.Add(CreateKey(typeof(ChildB), typeof(ChildA)), 3);
        addResults.Add(CreateKey(typeof(ChildB), typeof(ChildB)), 4);
      }
      
      public static int CreateKey(Type a, Type b)
      {
        return (String.Concat(a.Name, b.Name).GetHashCode());
      }
      
      public int Add(BaseClass next)
      {
        var result = default(int);
        
        if (!addResults.TryGetValue(CreateKey(this.GetType(), next.GetType()), out result))
        {
          throw new ArgumentOutOfRangeException("Unknown operand combination");
        }
        
        return result;
      }
    }
 
    public class ChildA : BaseClass {}
    public class ChildB : BaseClass {}
