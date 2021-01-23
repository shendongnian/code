    public class ContentViewModel
    {
        public ContentViewModel(SomeType pk)
        {
            Content = new Content(pk); //use pk in the Content constructor to set other params
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
