    [Serializable]
    public class getGamesList
    {
        [XmlElement("...")]
        public int id { get; set; }
        [XmlElement("...")]
        public string title { get; set; }        
        [XmlElement("ReleaseDate")]
        public string release { get; set; }        
        [XmlElement("...")]
        public string platform { get; set; }
    }
