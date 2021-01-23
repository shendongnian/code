    [XmlRoot("jobInfo", Namespace="http://www.force.com/2009/06/asyncapi/dataload"]
    public class JobInfo
    {
        [XmlAttribute]
        public string xmlns { get; set; }
        [XmlElement(ElementName = "id")]
        public string id { get; set; }
        ....
    }
