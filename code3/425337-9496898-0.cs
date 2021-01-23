    public class Wrapper<T> where T : struct
    {
        private T _value;
        public T Value { get; set; }
    }
