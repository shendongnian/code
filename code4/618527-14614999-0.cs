    [XmlRoot("inboxRecords")]
    public sealed class QueueQueryResult
    {
        [XmlArrayItem("inboxRecord")]
        public InboxRecord[] InboxRecords;
    
        public QueueQueryResult()
        {
            InboxRecords = null;
        }
    
        public sealed class InboxRecord
        {
            public string field1 { get; set; }
            public string field2 { get; set; }
            public string field3 { get; set; }
        }
    }
