    [XmlRoot(ElementName = "location", IsNullable = true)]
    public class location
    {
        public string city { get; set; }
        public string country { get; set; }
        public string street { get; set; }
        public string postalcode { get; set; }
        [XmlElement(ElementName = "point", Namespace = "http://www.w3.org/2003/01/geo/wgs84_pos#")]
        public geoLocation geo { get; set; }
    }
    
    public class geoLocation
    {
        [XmlElement(ElementName = "lat", Namespace = "http://www.w3.org/2003/01/geo/wgs84_pos#")]
        public string lat { get; set; }
        [XmlElement(ElementName = "long", Namespace = "http://www.w3.org/2003/01/geo/wgs84_pos#")]
        public string lon { get; set; }
    }
    
    var serializer = new XmlSerializer(typeof (location));
    var namespaces = new XmlSerializerNamespaces(new [] { new XmlQualifiedName("geo", "http://www.w3.org/2003/01/geo/wgs84_pos#"), });
    serializer.Serialize(myOutputStreamOrWriter, location, namespaces);
