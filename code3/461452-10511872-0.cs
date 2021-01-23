    [DataContract]
    public class ResponseItem
    {
        [DataMember(Name = "status")]
        public ListStatus Status { get; set; }
        [DataMember(Name = "since")]
        public double Since { get; set; }
        [DataMember(Name = "list")]
        public Dictionary<string, RilListItem> items { get; set; }
        public DateTime SinceDate
        {
            get
            {
                return UnixTime.ToDateTime(Since);
            }
        }
