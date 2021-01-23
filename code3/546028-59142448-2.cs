    [XmlRoot(ElementName = "errorNotification", Namespace = "http://def")]
    public class ErrorNotification
    {
        [XmlAttribute(AttributeName = "vcs-pos", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string VcsPosNamespace { get; set; }
        [XmlAttribute(AttributeName = "vcs-device", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string VcsDeviceNamespace { get; set; }
        [XmlElement(ElementName = "errorText", Namespace = "")]
        public string ErrorText { get; set; }
    }
