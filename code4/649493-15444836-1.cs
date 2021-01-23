    public static class Extensions
    {
        public static T ConvertTo<T>(this object obj) where T : IConvertible
        {
            try
            {
                return (T)Convert.ChangeType(obj, typeof(T));
            }
            catch
            {  // handle as needed/required
            }
            return default(T);
        }
    }
