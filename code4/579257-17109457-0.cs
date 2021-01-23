    [DataContract]
    public class SomeJson
    {
        [DataMember(Name = "toptags")]
        public Tags TopTags { get; set; }
    }
    [DataContract]
    public class Tags
    {
        [DataMember(Name = "@attr")]
        public Attr Attr { get; set; }
    }
    [DataContract]
    public class Attr
    {
        [DataMember(Name = "artist")]
        public string Artist { get; set; }
        [DataMember(Name = "album")]
        public string Album { get; set; }
    }
