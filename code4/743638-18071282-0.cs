    [XmlInclude(typeof(Song))]
    public abstract class myMediaInterface
    {
        public abstract string type { get; set; }
        public string path { get; set; }
        public String artist { get; set; }
        public String title { get; set; }
        public String album { get; set; }
        public uint trackNumber { get; set; }
        public String genre1 { get; set; }
        public TimeSpan duration { get; set; }
        public uint rating { get; set; }
        public uint bitrate { get; set; }
        public uint year { get; set; }
        public List<String> genre { get; set; }
        public int indexWithinParentCollection { get; set; }
        public string displayName { get; set; }
    }
    public class Song : myMediaInterface
    {
        public override String type
        {
            get
            {
                return "Song";
            }
            set
            {
                value = "Song";
            }
        }
    }
