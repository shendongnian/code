    public class NumberContainer<T>
    {
        public T ValueA { get; private set; }
        public T ValueB { get; private set; }
        public T Total
        {
            get
            {
                if (ValueA is int)
                {
                    return (T)((int)ValueA + (int)ValueB);
                }
            }
        }
    }
