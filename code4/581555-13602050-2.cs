    [ServiceContract]
    public interface ITransferService
    {
        [OperationContract]
        RemoteFileInfo DownloadFile(DownloadRequest request);
 
        [OperationContract]
        void UploadFile(RemoteFileInfo request); 
    }
    [MessageContract]
    public class DownloadRequest
    {
        [MessageBodyMember]
        public string FileName;
    }
    [MessageContract]
    public class RemoteFileInfo : IDisposable
    {
        [MessageHeader(MustUnderstand = true)]
        public string FileName;
    [MessageHeader(MustUnderstand = true)]
    public long Length;
    [MessageBodyMember]
    public System.IO.Stream FileByteStream;
    public void Dispose()
    { 
        if (FileByteStream != null)
        {
            FileByteStream.Close();
            FileByteStream = null;
        }
    }   
