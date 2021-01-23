    public class FooList<T> : List<T>
    {
        public new void Add(T item)
        {
            // any FooList-specific logic regarding adding items
            base.Add(item);
        }
    }
