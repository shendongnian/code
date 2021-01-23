    private static IEnumerable<T> GetAllEnumValues<T>() 
    {
       //check if T is an enum
       foreach (var info in typeof(T).GetFields(BindingFlags.Public | BindingFlags.Static))
       {
           yield return (T) info.GetRawConstantValue();
       }
    }
