    interface IItem
    {
        bool IsGood { get; set; }
    }
    class ItemsContainer<T>
        where T : IItem
    {
        private readonly List<T> items = new List<T>();
        public IEnumerable<T> GoodItems
        {
            get { return items.Where(item => item.IsGood); }
        }
        // ...
    }
    // somewhere in code
    class Item : IItem { /* ... */ }
    var container = new ItemsContainer<Item>();
    Console.WriteLine(container.GoodItems == container.GoodItems); // False; Oops!
