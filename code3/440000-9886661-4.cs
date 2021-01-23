    public class RenderableComparer : IComparer<IRenderable>
    {
      private static readonly Dictionary<Type, Dictionary<Type, int>> order;
    
      // Initialize comparisons once from the attributes.
      static RenderableComparer()
      {
        order = new Dictionary<Type, Dictionary<Type, int>>();
        foreach(Type rType in GetAllRenderableTypes())
        {
           BeforeAttribute before = rType.GetCustomAttributes(typeof(BeforeAttribute), false).SingleOrDefaut();
           BeforeAttribute after = rType.GetCustomAttributes(typeof(AfterAttribute), false).SingleOrDefaut();
           if (before != null)
           {
              AddToOrdering(rType, before.Type, -1);
              AddToOrdering(before.Type, rType, 1);
           }    
           if (after!= null)
           {
              AddToOrdering(rType, after.Type, 1);
              AddToOrdering(after.Type, rType, -1);
           }    
        }
     }
     public int Compare(IRenderable a, IRenderable b)
     {
        Dictinoary<Type, int> rules = null;
        if (!order.TryGetValue(a, out rules))
          return null;
        int result = 0;
        rules.TryGetValue(b, out result);
        return result;
     }
    }
