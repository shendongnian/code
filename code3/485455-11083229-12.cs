    [ProtoContract]
    public class V3DDelta
    {
        [ProtoMember(1)]
        public int bid { get; set; }
        [ProtoMember(2)]
        public int bidSize { get; set; }
        [ProtoMember(3)]
        public int ask { get; set; }
        [ProtoMember(4)]
        public int askSize { get; set; }
    }
