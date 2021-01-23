    public class ReturnData 
    {
        public int totalCount { get; set; }
        public List<ExceptionReport> reports { get; set; }  
    }
    
    public class ExceptionReport
    {
        public int reportId { get; set; }
        public string message { get; set; }  
    }
    string json = JsonConvert.SerializeObject(myReturnData);
