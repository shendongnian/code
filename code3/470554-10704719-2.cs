    [DataServiceKey("PartitionKey", "RowKey")]
    public class NoticeStatusUpdateEntry
    {
        public string PartitionKey { get; set; }   
        public string RowKey { get; set; }
        public string NoticeProperty { get; set; }
        public string StatusUpdateProperty { get; set; }
        public string Type
        {
           get 
           {
               return String.IsNullOrEmpty(this.StatusUpdateProperty) ? "Notice" : "StatusUpate";
           }
        }
    }
