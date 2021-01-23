    public class Tag
    {
        public int TagId { get; set; }
        public string Name { get; set; }
        // If your tags will be more freeform (and not necessarily URL compatible)
        public string Slug { get; set; }
    }
    public class Place
    {
        ...
        public virtual ICollection<Tag> Tags
    }
