    public class DefaultConverter<T> : IConverter<T>
    {
        public T Convert(object value)
        {
            return System.Convert.ChangeType(value, targetType);
        }
    }
