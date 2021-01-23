    public interface IPacketWrapper
    {
       IEnumerable<byte> Payload { get; }
       UserInfo UserDetails { get; }
    }
