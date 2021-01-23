    public class Report
    {
        public string Id
        {
          get { return string.Format("reports/{0}/Q{1}/{2}", Year, Quarter, User); }
        }
        public string User { get; set; }
        public int Quarter { get; set; }
        public int Year { get; set; }
        public string ReportData { get; set; }
    }
