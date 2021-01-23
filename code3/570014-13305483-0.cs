    [Class(Table = "SessionReportSummaries", Mutable = false)]
    public class SessionReportSummaries
    {        
        [ManyToOne(Column = "ClientId", Fetch = FetchMode.Join)]
        public Client Client { get; private set; }
    
        [ManyToOne(Formula = "ClientId", Fetch = FetchMode.Join)]
        public ClientReportSummary ClientReportSummary { get; private set; }
    }
