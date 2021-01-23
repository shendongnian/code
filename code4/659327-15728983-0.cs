    DataContract]
    public class AllFile
    {
        [DataMember(IsRequired = true)]
        public string base64Data { get; set; }
    }
    [DataContract]
    public class UploadFile : AllFile
    {
    
    }
    
    ServiceReference.UploadFile obj = new ServiceReference.UploadFile();
    obj.base64Data = "something";
    AllFile file = (UploadFile)obj;
