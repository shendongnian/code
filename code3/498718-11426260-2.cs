    public class Content
    {
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public bool UseRowKey()
        {
            return PartitionKey.Substring(2, 2) == "05" ||
                       PartitionKey.Substring(2, 2) == "06";
            
        }
    }
    public class ContentViewModel
    {
        public ContentViewModel() { }
        public Content Content { get; set; }
        public bool UseRowKey
        {
            get
            {
                return this.Content.UseRowKey();
            }
        }
    }
