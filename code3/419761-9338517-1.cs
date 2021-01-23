    public abstract class NumberContainer<T>
        where T: struct
    {
        public T ValueA { get; private set; }
        public T ValueB { get; private set; }
        public abstract T Total();
    }
    public class IntContainer : NumberContainer<int>
    {
        public override int Total()
        {
            return ValueA + ValueB;
        }
    }
