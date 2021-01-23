    public static class SpecificBooleanConverter
    {
        private static Dictionary<string, bool> _AllowedValues;
        static SpecificBooleanConverter()
        {
            _AllowedValues = new Dictionary<string, bool>(StringComparer.CurrentCultureIgnoreCase);
            _AllowedValues.Add("true", true);
            _AllowedValues.Add("false", false);
            _AllowedValues.Add("foo", true);
            _AllowedValues.Add("bar", false);
        }
        public static bool TryParse(string value, out bool result)
        {
            return _AllowedValues.TryGetValue(value, out result);
        }
    }
