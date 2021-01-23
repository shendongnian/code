    [XmlRoot("indexFields")]
    public class IndexFields
    {
        [XmlElement("indexField")]
        public List<IndexField> NestedIndexFields { get; set; }
        public IndexFields() { }
    }
