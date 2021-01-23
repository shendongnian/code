    [XmlRoot("jobInfo", Namespace = "http://www.force.com/2009/06/asyncapi/dataload")]
    public class JobInfo
    {
        [XmlElement("id")]
        public string Id { get; set; }
        
        [XmlElement("operation")]
        public string Operation { get; set; }
        
        [XmlElement("object")]
        public string Object { get; set; }
        
        [XmlElement("createdById")]
        public string CreatedById { get; set; }
        
        [XmlElement("createdDate")]
        public DateTime CreatedDate { get; set; }
        
        [XmlElement("systemModstamp")]
        public DateTime SystemModstamp { get; set; }
        
        [XmlElement("state")]
        public string State { get; set; }
        
        [XmlElement("concurrencyMode")]
        public string ConcurrencyMode { get; set; }
        
        [XmlElement("contentType")]
        public string ContentType { get; set; }
        
        [XmlElement("numberBatchesQueued")]
        public string NumberBatchesQueued { get; set; }
        
        [XmlElement("numberBatchesInProgress")]
        public string NumberBatchesInProgress { get; set; }
        
        [XmlElement("numberBatchesCompleted")]
        public string NumberBatchesCompleted { get; set; }
        
        [XmlElement("numberBatchesFailed")]
        public string NumberBatchesFailed { get; set; }
        
        [XmlElement("numberBatchesTotal")]
        public string NumberBatchesTotal { get; set; }
        
        [XmlElement("numberRecordsProcessed")]
        public string numberRecordsProcessed { get; set; }
        
        [XmlElement("numberRetries")]
        public string NumberRetries { get; set; }
        
        [XmlElement("apiVersion")]
        public string ApiVersion { get; set; }
    }
