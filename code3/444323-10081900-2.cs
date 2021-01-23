    public class EqualFilter<T> : Filter where T : IConvertible {
        // ... omitted Value property code ...
        public void SetValue(string value)
        {
            Value = (T)Convert.ChangeType(value, typeof(T));
        }
        // ...
    }
