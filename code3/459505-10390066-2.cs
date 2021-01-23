    public partial class MessageBase
    {
        // Virtual Execute method following the Command pattern
        public virtual string Execute(Socket socket) { return string.Empty; }
        protected virtual bool MustEncrypt
        {
            get { return false; }
        }
        // Binary serialization
        public byte[] Serialize()
        {
            using (MemoryStream stream = new MemoryStream())
            {
                using (DeflateStream ds = new DeflateStream(stream, CompressionMode.Compress, true))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(ds, this);
                    ds.Flush();
                }
                byte[] bytes = stream.GetBuffer();
                byte[] bytes2 = new byte[stream.Length];
                Buffer.BlockCopy(bytes, 0, bytes2, 0, (int)stream.Length);
