    public class Flow
    {
        public int CurrentHop { get; set; }
        public int TotalHops { get; set; }
        [XmlArrayItem(ElementName = "Hop", IsNullable = false)]
        public List<tblTaskHop> TaskHops { get; set; }
    }
