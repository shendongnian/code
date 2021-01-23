    [ProtoContract]
    public class MercuryReply
    {
        [ProtoMember(1)]
        public string Location { get; set; }
        [ProtoMember(2)]
        public string ContentType { get; set; }
        [ProtoMember(4)]
        public int ResponseStatus { get; set; }
        [ProtoMember(6)]
        public Dictionary<string, string> Headers { get { return headers; } }
        private readonly Dictionary<string, string> headers
            = new Dictionary<string, string>();
    }
