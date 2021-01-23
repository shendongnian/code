    public class NumberContainer<T> where T: struct
    {
        public T ValueA { get; private set; }
        public T ValueB { get; private set; }
        public T Total { get { return ((dynamic)ValueA) + ((dynamic)ValueB); } }
    }
