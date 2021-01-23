    public static class Extensions
        {
            public static T ToEnum<T>(this int param)
            {
                var info = typeof(T);
                if (info.IsEnum)
                {
                    T result = (T)Enum.Parse(typeof(T), param.ToString(), true);
                    return result;
                }
    
                return default(T);
            }
        }
