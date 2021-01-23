    public class GenericsTest<T> where T:IEquatable<T>
    {
        public bool Check(T value)
        {
            return value.Equals(default(T));
        }
    
        protected Func<T, bool> func;
    }
