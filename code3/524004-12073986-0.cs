    public class Tag
    {
        public string Name { get; set; }
        public bool IsChecked { get; set; }
    }
    
    public class MyModel
    {
        public string Name { get; set; }
        public List<Tag> Tags { get; set; }
    }
