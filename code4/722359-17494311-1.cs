    public class NestedItemsViewModel
    {
        public List<Level1Item> Level1 { get; set; }
    }
    public class Level1Item
    {
        public List<Level2Item> Level2 { get; set; }
    }
    public class Level2Item
    {
        public string Value { get; set; }
    }
