    [DataContract, KnownType(typeof(EchoPacketHandler)]
    public class PacketHandler {
        public virtual Packet Handle(Packet packet) { throw new NotSupportedException(); }
    }
    [DataContract]
    public class EchoPacketHandler : PacketHandler {
        public override Packet Handle(Packet packet) { return packet; }
    }
