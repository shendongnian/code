    [ProtoBuf.ProtoContract]
    public class Sample
    {
        public Sample()
        {
        }
        [ProtoBuf.ProtoMember(2)]
        public double Max { get; set; }
        [ProtoBuf.ProtoMember(3)]
        public double Mean { get; set; }
        [ProtoBuf.ProtoMember(1)]
        public double Min { get; set; }
    }
    [ProtoBuf.ProtoContract]
    public class Scan
    {
        public Scan()
        {
        }
        [ProtoBuf.ProtoMember(1)]
        public Sample[] Samples { get; set; }
    }
    public class Surface
    {
        public Surface()
        {
        }
        
        public int Id { get; set; }
        public byte[] ScanData { get; set; }
        [NotMapped]
        public Scan[] Scans
        {
            get
            {
                return this.Unpack();
            }
            set
            {
                this.ScanData = this.Pack(value);
            }
        }
        private byte[] Pack(Scan[] value)
        {
            using (var stream = new MemoryStream())
            {
                ProtoBuf.Serializer.Serialize(stream, value);
                return stream.ToArray();
            }
        }
        private Scan[] Unpack()
        {
            using (var stream = new MemoryStream(this.ScanData))
            {
                return ProtoBuf.Serializer.Deserialize<Scan[]>(stream);
            }
        }
    }
