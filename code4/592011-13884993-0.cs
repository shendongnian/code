    public class Guid 
    {
        [XmlAttribute]
        public bool IsPermaLink { get; set; }
        // and the element value
        [XmlTextAttribute]
        public string Value;
    }
    ...
    var theGuid = someItem.Value;
    var guidIsPermaLink = someItem.IsPermaLink;
