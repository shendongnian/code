    public class PropertyComparer<T> : IEqualityComparer<T>
    {
        private readonly PropertyInfo propertyToCompare;
        
        public PropertyComparer(string propertyName)
        {
            propertyToCompare = typeof(T).GetProperty(propertyName);
        }
        public bool Equals(T x, T y)
        {
            object xValue = propertyToCompare.GetValue(x, null);
            object yValue = propertyToCompare.GetValue(y, null);
            return xValue.Equals(yValue);
        }
        
        public int GetHashCode(T obj)
        {
            object objValue = propertyToCompare.GetValue(obj, null);
            return objValue.GetHashCode();
        }
    }
