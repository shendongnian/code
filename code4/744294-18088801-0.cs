    public interface IMyData {
        IdType MyId { get; }
        byte[] BlobData { get; }
        long SizeOfBlob { get; }
    }
    public class MyData : IMyData {
        public IdType MyId { get; private set; }
        public byte[] BlobData { get; set; }
        public long SizeOfBlob { get { return BlobData.LongLength; } }
        }
    }
