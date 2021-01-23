    [DataContract]
    public class Project
    {
        [DataMember(Name = "NameOfTheProject")]
        public string ProjectName { get; set; }
        [DataMember(Name = "ProjectLocation")]
        public string Location { get; set; }
    }
    [Serializable]
    public class Project1
    {
        [System.Xml.Serialization.XmlAttribute(AttributeName = "ProjectName")]
        public string ProjName { get; set; }
    }
