    public class TypedDictionary : Dictionary<Type, object>
    {
        public void Add<T>(T value)
        {
            var type = typeof (T);
            if (ContainsKey(type))
                this[type] = value;
            else
                Add(type, value);
        }
        public T Get<T>()
        {
            // Will throw KeyNotFoundException
            return (T) this[typeof (T)];
        }
        public bool TryGetValue<T>(out T value)
        {
            var type = typeof (T);
            object intermediateResult;
            if (TryGetValue(type, out intermediateResult))
            {
                value = (T) intermediateResult;
                return true;
            }
            value = default(T);
            return false;
        }
    }
