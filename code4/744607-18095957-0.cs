     public static object GetPropValue(Type src, string propName)
     {
         var prop = src.GetProperty(propName);
         var instance = Activator.CreateInstance(src);
         var value = prop.GetValue(instance);
         return value;
     }
