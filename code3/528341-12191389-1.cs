    class ItemsContainer<T>
        where T : IItem
    {
        private readonly List<T> items;
        private readonly Lazy<IEnumerable<T>> goodItems;
        public ItemsContainer()
        {
            this.items = new List<T>();
            this.goodItems = new Lazy<IEnumerable<T>>(() => items.Where(item => item.IsGood));
        }
        public IEnumerable<T> GoodItems
        {
            get { return goodItems.Value; }
        }
        // ...
    }
