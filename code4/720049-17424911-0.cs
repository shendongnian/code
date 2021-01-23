    [Serializable]
    [XmlRoot(ElementName = "dataSet")]
    public class RootDataSet
    {
        [XmlElement(ElementName = "row")]
       public  List<Rows> Rows { get; set; }
    }
    [Serializable]
    public class Rows
    {
        [XmlElement(ElementName = "column")]
        public List<string> column { get; set; }
    }
