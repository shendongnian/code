    public class Epic
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? FeatureId { get; set; }
        public int? ParentEpicId { get; set; }
        public virtual ICollection<Epic> ChildEpics { get; set; } 
    }
