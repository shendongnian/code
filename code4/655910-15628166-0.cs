    public static class ClassExtensions
        {
            public static TRes GetPublicPropertyValue<T,TRes>(this T queryObject, string propertyMatch) 
                where T : class,new()
                where TRes : new()
               
            {
                return (TRes)typeof(T).GetProperty(propertyMatch, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance).GetValue(queryObject, null);
            }
        }
