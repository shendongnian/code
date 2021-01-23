    public class Constraints
    {
        public IEnumerable GetEnumValueRange(Type enumType)
        {
            // Logic here
        }
        public IEnumerable<T> GetEnumValueRange<T>()
        {
            return GetEnumValueRange(typeof(T)).Cast<T>();
        }
    }
