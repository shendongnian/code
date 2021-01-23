    public class YourClass<T> where T : IHaveLocation, IHaveColor
    {
        List<T> items = new List<T>;
        public void Add(T item)
        {
            items.Add(item);
        }
        // ...
    }
