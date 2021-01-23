    [ProtoBuf.ProtoContract]
    public struct Transfer_packet
    {
        [ProtoBuf.ProtoMember(1)]
        public int _packet_type; // 0 is action 1 is data
        [ProtoBuf.ProtoMember(2)]
        public int _packet_len; // length of data
        [ProtoBuf.ProtoMember(3)]
        public byte[] _data;//Content of data it's Length depends on objects types 
    
        /// <summary>
        /// Private constructor required by protobuf
        /// </summary>
        private Transfer_packet() { }
    }
    
