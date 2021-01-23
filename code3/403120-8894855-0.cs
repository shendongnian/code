    [DataContract]
    public class ProgressReportWcf
    {
        [DataMember]
        public int Id { get; set; }
        //aso...
    
        public ProgressReportWcf(ProgressReport report)
        {
            Id = report.Id;
            //aso...
        }
    }
