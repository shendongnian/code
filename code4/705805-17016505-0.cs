    public class CustomPropertyEqualityComparer<T>: IEqualityComparer<T> where T : class
    {
        private readonly string[] _selectedComparisonProperties;
        public CustomPropertyEqualityComparer(params string[] selectedComparisonProperties)
        {
            _selectedComparisonProperties = selectedComparisonProperties;
        }
        public bool Equals(T x, T y)
        {
            if (x != null && y != null && x.GetType() == y.GetType())
            {
                var type = x.GetType();
                var comparableProperties = new List<string>(_selectedComparisonProperties);
                var objectProperties = type.GetProperties();
                var relevantProperties = objectProperties.Where(propertyInfo => comparableProperties.Contains(propertyInfo.Name));
                foreach (var propertyInfo in relevantProperties)
                {
                    var xPropertyValue = type.GetProperty(propertyInfo.Name).GetValue(x, null);
                    var yPropertyValue = type.GetProperty(propertyInfo.Name).GetValue(y, null);
                    if (xPropertyValue != yPropertyValue && (xPropertyValue == null || !xPropertyValue.Equals(yPropertyValue)))
                    {
                        return false;
                    }
                }
                return true;
            }
            return x == y;
        }
        public int GetHashCode(T obj)
        {
            var type = typeof(T);
            var objectProperties = type.GetProperties();
            return objectProperties.Sum(property => property.GetHashCode());
        }
    }
