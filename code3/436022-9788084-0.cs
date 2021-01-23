    public class MyConvert
    {
        public static char ToChar(object value, char defaultValue)
        {
            return Convert.IsDBNull(value) ? defaultValue : Convert.ToChar(value);
        }
    }
