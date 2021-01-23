    public class owner
    {
        [XmlAttributeAttribute]
        public string username { get; set; }
    }
    [SerializableAttribute] 
    [XmlTypeAttribute(AnonymousType = true)] 
    public partial class SearchResponseVideosWrapperVideo 
    { 
        private string _title; 
        private string _id; 
        private string _username; 
 
        [XmlElement()] 
        public string title 
        { 
            get { return _title; } 
            set { _title = value; } 
        } 
 
        [XmlAttributeAttribute()] 
        public string id 
        { 
            get { return _id; } 
            set { _id = value; } 
        } 
 
        [XmlElementAttribute("owner")] 
        public owner owner { get; set; }       
} 
