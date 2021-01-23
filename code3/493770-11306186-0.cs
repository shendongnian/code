    public class MyNode
    {
        public MyNode Parent { get; set; }
        public ObservableCollection<MyNode> Children { get; set; }
        public string ItemId { get; set; }
        // ...
    }
