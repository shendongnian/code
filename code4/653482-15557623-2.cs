    Type enumerable = typeof(T).GetInterface("System.Collections.Generic.IEnumerable`1");
    if (enumerable != null)
    {
       Type v = enumerable.GetGenericArguments()[0];
       var baseMethod = typeof(TheClass).GetMethod("GetEnum", flags);
       var realMethod = baseMethod.MakeGenericMethod(v);
       return (T)(object)realMethod.Invoke(null, new[] { key });
    }
