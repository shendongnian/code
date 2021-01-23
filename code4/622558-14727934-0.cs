    [ProtoContract]
    public struct Packet {    
        [ProtoMember(1)] public int opcode;
        [ProtoMember(2)] public string message;
    }
