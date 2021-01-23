    public static class StringExtensions
    {
        public static int GetMaxLength<T>(this T obj, string propertyName) where T : class
        {
            if (obj != null)
            {
                var attrib = (StringLengthAttribute)obj.GetType().GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance)
                        .GetCustomAttribute(typeof(StringLengthAttribute), false);
                if (attrib != null)
                {
                    return attrib.MaximumLength;
                }
            }
            return -1;
        }
    }
