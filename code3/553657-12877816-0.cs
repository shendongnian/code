    public static class Store<T>
    {
        public static readonly T[] Values = new T[3];
        public static T A { get { return Values[0]; } set { Values[0] = value; } }
        public static T B { get { return Values[1]; } set { Values[1] = value; } }
        public static T C { get { return Values[2]; } set { Values[2] = value; } }
    }
    public static class Store
    {
        public static readonly Value A = new Value(0);
        public static readonly Value B = new Value(1);
        public static readonly Value C = new Value(2);
    }
    public class Value
    {
        private int _index;
        public Value(int index)
        {
            _index = index;
        }
        public void SetValue<T>(T value)
        {
            Store<T>.Values[_index] = value;
        }
        public T GetValue<T>()
        {
            return Store<T>.Values[_index];
        }
    }
