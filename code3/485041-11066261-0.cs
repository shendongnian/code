    public class ThingWithAddress<T>
    {
        public T Item { get; private set; }
        public string Address { get; private set; }
    
        public static ThingWithAddress<T> Create(T item, string address)
        {
            return new ThingWithAddress<T>
            {
                Item = item,
                Address = address,
            };
        }
    }
