    public class NowShowingInfo
    {
        public List<ShowInfo> ShowInformation { get; set; }
        public int MovieID { get; set; }
        public string Movie { get; set; }
        public string Screen { get; set; }
        public string MediaPath { get; set; }
    }
   
    public class ShowInfo
    {
        public int ShowID { get; set; }
        public string StartTime { get; set; }
    }
