    [XmlRoot(ElementName="project" ,Namespace = "http://maven.apache.org/POM/4.0.0")]
     public class POM
     {
        [XmlElement("modelVersion")]
        public string ModelVersion { get; set; }
     }
