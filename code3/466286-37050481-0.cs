    public static class Extensions
    {    
        public static Nullable<T> TryParse<T>(this String str) where T:struct
        {
            try
            {
                T parsedValue = (T)Convert.ChangeType(str, typeof(T));
                return parsedValue;
            }
            catch { return null; }
        }
    }
