    var t = p.PropertyType;
    if (t.IsGenericType && !t.IsGenericTypeDefinition && !t.IsInterface && !t.IsValueType) 
    {
       // we are dealing with closed generic classes 
       var typeToTest = typeof (List<>);
       var tToCheck = t.GetGenericTypeDefinition();
       while (tToCheck != typeof(object)) 
       {
          if (tToCheck == typeToTest) 
          {
             // the given type is indeed derived from List<T>
             break; 
          }
          tToCheck = toCheck.BaseType;
       }
    }
