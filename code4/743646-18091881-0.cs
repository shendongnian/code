    class Container<TContent> {
        public HashSet<Item<TContent>> Items { get; }
    }
    class Item<TContent> {
        public Container Parent;
        public TContent Content;
    }
