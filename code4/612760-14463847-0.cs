    public class ReplicationDateRange
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int StartId { get; set; }
        public int EndId { get; set; }
        public override string ToString()
        {
            return String.Format("{0}-{1} Replicate {2}-{3}", StartDate.ToShortDateString(), EndDate.ToShortDateString(), StartId, EndId);
        }
    }
