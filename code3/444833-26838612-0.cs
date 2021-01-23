    public class MediaAccountContent
    {
        public Guid IdMedia { get; set; }
        public string Value { get; set; }
        
    }
    public class User
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public List<MediaAccountContent> MediaAccountContents { get; set; }
    }
