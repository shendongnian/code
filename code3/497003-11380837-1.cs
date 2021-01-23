    public class ContentViewModel 
    { 
        public ContentViewModel(Content c) 
        {
            if (c == null) throw new InvalidOperationException("Cannot create Content VM with null content.");
            this.Content = c;
        }
        public ContentViewModel(object pk) : this(Guid.NewGuid()) {}
        public ContentViewModel(object pk)
        {
            this.Content = new Content(pk); 
            this.Content.PartitionKey = pk; 
            this.Content.Created = DateTime.Now; 
        }
        public Content Content { get; set; } 
        public bool UseRowKey {  
            get { 
                return Content.PartitionKey.Substring(2, 2) == "05" || 
                   Content.PartitionKey.Substring(2, 2) == "06"; 
            } 
        } 
        public string TempRowKey { get; set; } 
     
    } 
