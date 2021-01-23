    public static class NumericTypeExtension
    {
        public static bool IsNumeric(this Type dataType)
        {
            if (dataType == null)
                throw new ArgumentNullException("dataType");
            return (dataType == typeof(int)
                    || dataType == typeof(double)
                    || dataType == typeof(long)
                    || dataType == typeof(short)
                    || dataType == typeof(float)
                   );
        }
    }
