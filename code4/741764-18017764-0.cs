    public class historydetails
    {
        [XmlElement("taskEvent")]
        public List<taskEvent> eventList = new List<taskEvent>();
    }
      public class taskEvent
    {
        public string eventtype { get; set; }
        public string historyevent { get; set; }
        public string details { get; set; }
        public string author { get; set; }
        public string entrydate { get; set; }
        public string historyid { get; set; }
    }
