    [ValueConversion(typeof(Type), typeof(String))]
    internal sealed class TypeNameConverter : IValueConverter
    {
        private static readonly IDictionary<Type, string> TypeNameCache = new Dictionary<Type, string>();
        private static readonly object TypeNameCacheLock = new Object();
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var type = value as Type;
            if (type == null)
            {
                return DependencyProperty.UnsetValue;
            }
            string result;
            lock (TypeNameCacheLock)
            {
                if (!TypeNameCache.TryGetValue(type, out result))
                {
                    var instance = Activator.CreateInstance(type);
                    result = instance.ToString();
                    TypeNameCache.Add(type, result);
                }
            }
            return result;
        }
        ...
    }
