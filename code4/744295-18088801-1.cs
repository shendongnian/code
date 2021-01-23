    public class MyDataFlyWeight : IMyData {
        public MyDataFlyWeight(IdType myId, long blobSize){
            MyId = myId;
            BlobSize = blobSize;
        }
        public IdType MyId { get; set; }
        public byte[] MutableBlobData { get { 
                throw new NotImplmentedException();
                }
            }
        public long BlobSize { get; private set; }
        }
    }
