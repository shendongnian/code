    public class MyBinaryReader : BinaryReader
    {
        public MyBinaryReader(Stream s)  : base(s)
        {
        }
        public override short ReadInt16()
        {
            return IPAddress.HostToNetworkOrder(base.ReadInt16());
        }
    }
