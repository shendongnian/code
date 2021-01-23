    //paste this as a direct child of a namespace (not a nested class)
    public static class SO8877853Extensions
    {
      public static TArray[] FieldsToArray<TObj, TArray>(this TObj o,string fieldPrefix)
      {
        if(string.IsNullOrWhiteSpace(fieldPrefix))
          throw new ArgumentException("fieldPrefix must not null/empty/whitespace", 
          "fieldPrefix");
        //I've done this slightly more expanded than it really needs to be...
        var fields = typeof(TObj).GetFields(System.Reflection.BindingFlags.Instance
              | System.Reflection.BindingFlags.Public
              | System.Reflection.BindingFlags.NonPublic)
         .Where(f =>f.Name.StartsWith(fieldPrefix) && f.FieldType.Equals(typeof(TArray)))
         .Select(f =>new{ Field = f, OrdinalStr = f.Name.Substring(fieldPrefix.Length)})
         .Where(f => { int unused; return int.TryParse(f.OrdinalStr, out unused);})
         .Select(f => new { Field = f.Field, Ordinal = int.Parse(f.OrdinalStr) })
         .OrderBy(f => f.Ordinal).ToArray();  
         //doesn't handle ordinal gaps e.g. 0,1,2,7
        if(fields.Length == 0)
          throw new ArgumentException(
            string.Format("No fields found with the prefix {0}", 
                          fieldPrefix), 
            "fieldPrefix");
        //could instead bake the 'o' reference as a constant - but if 
        //you are caching the delegate, it makes it non-reusable.
        ParameterExpression pThis = Expression.Parameter(o.GetType());
        //generates a dynamic new double[] { var0, var1 ... } expression
        var lambda = Expression.Lambda<Func<TObj, TArray[]>>(
          Expression.NewArrayInit(typeof(TArray), 
          fields.Select(f => Expression.Field(pThis, f.Field))), pThis);
        //you could cache this delegate here by typeof(TObj) in a 
        //Dictionary/ConcurrentDictionary
        return lambda.Compile()(o);
      }
    }
