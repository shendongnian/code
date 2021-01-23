    public class Optional<T> where T : struct, IComparable
    {
        public Optional(T valueObject)
        {
            Value = valueObject;
        }
        public Optional()
        {
        }
        [XmlText]
        public T Value { get; set; }
        public static implicit operator T(Optional<T> objectToCast)
        {
            return objectToCast.Value;
        }
        public static implicit operator Optional<T>(T objectToCast)
        {
            return new Optional<T>(objectToCast);
        }
    }
