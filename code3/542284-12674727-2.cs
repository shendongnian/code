    public class IntIntDict<T> : Dictionary<long, T>
    {
        public void Add(int key1, int key2, T value)
        {
            Add((((long)key1) << 32) + key2, value);
        }
        //TODO: Overload other methods
    }
