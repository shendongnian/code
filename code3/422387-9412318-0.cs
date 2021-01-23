    [Serializable] 
    public class MenuItem
    { 
        public int ID { get; set; } 
        public string MenuText { get; set; } 
        public string MenuURL { get; set; } 
        public string ImageURL { get; set; } 
        // I'm not bothering with the code to protect access to the list
        // in this example but you might want that too...
        public List<MenuItem> MenuItems { get; set; }
    } 
