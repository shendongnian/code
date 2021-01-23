    public class MyData : IMyData {
        public IdType MyId { get; private set; }
    
        private Lazy<byte[]> _blob = new Lazy<byte[]>(() => 
                                     StaticBlobService.GetBlob(MyId));
        public byte[] BlobData { get { return _blob.Value; } }
        public long SizeOfBlob { get { return BlobData.LongLength; } }
        }
    }
