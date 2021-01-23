    public class Item<T>
    {
        public Item(T item)
        {
            Value = item;
        }
        public T Value;
        public Item<T> NextItem;
    }
