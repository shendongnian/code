    public class Guid 
    {
        [XmlAttribute]
        public bool IsPermaLink { get; set; }
        // and the element value
        [XmlTextAttribute]
        public string Value;
    }
    public class Item
    {
        [XmlElement]
        public Guid Guid { get; set; }
    }
    ...
    var theGuid = someItem.Guid.Value;
    var guidIsPermaLink = someItem.Guid.IsPermaLink;
