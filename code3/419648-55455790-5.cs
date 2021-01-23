    public class Settings
    {
        [UsePropertyNameToLowerAsXmlElement]
        public string VersionId { get; set; }
        [UsePropertyNameToLowerAsXmlElement]
        public int? ApplicationId { get; set; }
    }
