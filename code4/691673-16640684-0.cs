    public class Group<T> where T : Item
    {
        public ObservableCollection<T> Items { get; set;}
        public string Title { get; set; }
    }
    public class Item
    {
        public string Value { get; set; }
    }
