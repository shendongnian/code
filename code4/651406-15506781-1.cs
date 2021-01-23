    public interface IMerchant
    {
        bool UploadPhotoStream(UploadData request);
    }
    public class YourService : IMerchant
    {
        public bool UploadPhotoStream(UploadData request)
        {
 	        throw new NotImplementedException();
        }
    }
    [DataContract]
    public class UploadData
    {
        [DataMember]
        string ProductId { get; set; }
        [DataMember]
        string PhotoId { get; set; }
        [DataMember]
        System.IO.Stream FileData { get; set; }
    }
