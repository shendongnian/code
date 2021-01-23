        public static T ToType<T>(this string value)
        {
            object parsedValue = default(T);
            Type type = typeof(T);
            try
            {
                parsedValue = Convert.ChangeType(value, type);
            }
            catch (ArgumentException e)
            {
                parsedValue = null;
            }
            return (T) parsedValue;
        }
