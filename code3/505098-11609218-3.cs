    public class Filter
    {
        public int OrgId { get; set; }
        public List<FilterData> Drivers { get; set; }
        public List<FilterData> DrivenUnits { get; set; }
        public List<FilterData> Regions { get; set; }
        public List<FilterData> Operations { get; set; }
        public List<FilterData> Connections { get; set; }
        public string SearchString { get; set; }
    }
    public class FilterData
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
    }
