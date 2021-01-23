    public class NavigationItemCollection
    {
        public int Id { get; set; }
        public NavigationItem NavigationItem { get; set; } // NavigationItemId
        public string LinkText { get; set; }
        public string ImageUrl { get; set; }
        public int PageId { get; set; } // The URL the link will navigate to
        public string CssGroup { get; set; }
    }
