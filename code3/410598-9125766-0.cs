    public class Item 
    {
        public string Group { get; set; } // A prop you want the grouping on
        public string AnotherItemProp { get; set; } 
    }
    
    public IEnumerable<Item> Items // used as your list source somewhere
