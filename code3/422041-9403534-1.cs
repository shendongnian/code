    public class job
    {
        public string title { get; set; }
        public string company { get; set; }
        public string companywebsite { get; set; }
        [XmlArray("locations")]
        [XmlArrayItem("location")]
        public string[] locations { get; set; }
    }
