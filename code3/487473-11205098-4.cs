    [DataContract]
    public class FileDownloadDTO : IDisposable, IDTOBase
    {
       [DataMember]
       public string FileName { get; set; }
       [DataMember]
       public long Length { get; set; }
       [DataMember]
       public int Id { get; set; }
    }
