    public class Document
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public virtual DocumentType DocumentType { get; set; }
    }
