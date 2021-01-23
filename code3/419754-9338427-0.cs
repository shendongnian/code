    public class NumberContainer<T>
      where T : struct, IConvertable
    {
        public T ValueA { get; private set; }
        public T ValueB { get; private set; }
        public T Total { get { return (T)(Convert.ChangeType(ValueA, typeof(T)) + Convert.ChangeType(ValueB, typeof(T))); } }
    }
