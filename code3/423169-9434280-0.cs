    public static class MyConverter
    {
        private static Dictionary<Type, Func<string, object>> _Converters;
        static MyConverter()
        {
            _Converters = new Dictionary<Type, Func<string, object>>();
            // Add converter from available method
            _Converters.Add(typeof(double), MySpecialConverter);
            // Add converter as lambda
            _Converters.Add(typeof(bool), (text) => bool.Parse(text));
            // Add converter from complex lambda
            _Converters.Add(typeof(int), (text) =>
            {
                if (String.IsNullOrEmpty(text))
                {
                    throw new ArgumentNullException("text");
                }
                return int.Parse(text);
            });
        }
        private static object MySpecialConverter(string text)
        {
            return double.Parse(text);
        }
        public static object Convert(Type type, string value)
        {
            Func<string, object> converter;
            if (!_Converters.TryGetValue(type, out converter))
            {
                throw new ArgumentException("No converter for type " + type.Name + " available.");
            }
            return converter(value);
        }
    }
