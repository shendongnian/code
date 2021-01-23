    public static class ConversionExtensions
    {
        public static string SafeDateTime(this object value)
        {
            if (value == DBNull.Value) return string.Empty;
            var valueType = value.GetType();
            if (typeof (DateTime?).IsAssignableFrom(valueType))
            {
                var nullableValue = value as DateTime?;
                if (nullableValue == null) return string.Empty;
                return nullableValue.Value.ToString();
            }
            if (typeof (DateTime).IsAssignableFrom(valueType))
            {
                return ((DateTime) value).ToString();
            }
            return string.Empty;
        }
    }
