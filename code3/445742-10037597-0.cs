    [XmlRoot("info")]
    public class Response
    {
        [XmlElement("result")]
        public Result Result { get; set; }
        [XmlElement("songlist")]
        public SongList SongList { get; set; }
    }
    public class Result
    {
        [XmlAttribute("resultCode")]
        public int ResultCode { get; set; }
        [XmlText]
        public string Value { get; set; }
    }
    public class SongList
    {
        [XmlElement("song")]
        public Song[] Songs { get; set; }
    }
      
    public class Song
    {
        [XmlElement("id")]
        public string Id { get; set; }
    }
