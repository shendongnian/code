    public class Navigation
    {
        public int Id { get; set; }
        public string PageNavigation { get; set; } // The page name
        public string Description { get; set; }
        public int SortOrder { get; set; }
        public int Location { get; set; } // So you can order from one side to another
    }
