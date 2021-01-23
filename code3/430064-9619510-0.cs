    public class MenuItem
    {
        public MenuItem()
        {
            SubItems = new List<MenuItem>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public bool Active { get; set; }
        public bool Action { get; set; }
        public string Path { get; set; }
        public List<MenuItem> SubItems { get; private set; }
    }
