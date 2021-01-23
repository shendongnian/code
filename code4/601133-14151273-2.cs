    public interface INullValueDictionary<T, U>
        where U : class
    {
        U this[T key] { get; }
    }
    public class NullValueDictionary<T, U> : Dictionary<T, U>, INullValueDictionary<T, U>
        where U : class
    {
        U INullValueDictionary<T, U>.this[T key]
        {
            get
            {
                if (ContainsKey(key))
                    return this[key];
                else
                    return null;
            }
        }
    }
