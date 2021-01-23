    [DataContract]
        public class Result
        {
            [DataMember(Name="responseCode")]
            public int Code { get; set; }
    
            [DataMember(Name="responseObject")]
            public ResponseObject Result { get; set; }
        }
    
        [DataContract]
        public class ResponseObject
        {
            [DataMember]
            public int TotalRecords { get; set; }
    
            [DataMember]
            public int TotalDisplayRecords { get; set; }
    
            [DataMember(Name="aaData")]
            public DataItem[] Data { get; set; }
        }
    
        [DataContract]
        public class DataItem
        {
            [DataMember(Name = "InvoiceId")]
            public int InvoiceId { get; set; }
    
            // Others properties
        }
