    public class Group
    {
        public string AnotherGroupProp { get; set; } // grouping value from flattened
        public IEnumerable<Item> Items { get; set; }
    }
    public class Item
    {
        public string AnotherItemProp { get; set; }
    }   
        
    public IEnumerable<Group> Groups { get; set; } // Used by treeview
