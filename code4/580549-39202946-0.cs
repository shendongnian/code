     public class TransportResponse
    {
        public string directoryName { get; set; }
        public string fileName { get; set; }
        public DateTime fileTimeStamp { get; set; }
        public MemoryStream fileStream { get; set; }
        public List<TransportResponse> lstTransportResponse { get; set; }
    }
   
