    [ServiceContract]
    public interface IFileDownloadService
    {
        [OperationContract]
        StreamResponse DownloadFile(DownloadFileCommandRequest command);
    }
    [MessageContract]
    public class StreamResponse
    {
        [MessageHeader()]
        public CommandResult<FileDownloadDTO> {get; set;}
        [MessageBodyMember(Order = 1)]
        public Stream FileByteStream { get; set; }
    }
    [MessageContract]
    public class DownloadFileCommandRequest 
    {
        [MessageBodyMember(Order = 1)]
        public DownloadFileCommand FileCommand {get; set;}
    }
