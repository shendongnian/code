    [DataContract]
    public class MusicInfo
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Artist { get; set; }
        [DataMember]
    	public string Genre { get; set; }
        [DataMember]
    	public string Album { get; set; }
        [DataMember]
    	public string AlbumImage { get; set; }
        [DataMember]
    	public string Link { get; set; }
    }
