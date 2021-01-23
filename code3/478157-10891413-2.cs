    public class Document : Entity // don't worry about Entity; it's a base type I created that contains the Id property
    {
        public virtual string Name { get; set; }
    
        public virtual IList<DocumentOptions> Options { get; protected set; }
    
        public Document()
        {
            Options = new List<DocumentOptions>();
        }
    }
    public class DocumentOptions
    {
        public virtual int Type { get; set; }
        public virtual string Value { get; set; }
    }
