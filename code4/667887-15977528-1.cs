    public class Document
    {
        [JsonConverter(typeof(DocumentEntryCreationConverter))]
        public class Entry
        {
            public string Value { get; set; }
            public DateTime Timestamp { get; set; }
        }
       
        public Entry[] Array { get; set; }
    }
