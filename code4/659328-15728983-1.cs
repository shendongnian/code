    [DataContract]
    public class AllFile
    {
        [DataMember(IsRequired = true)]
        public string base64Data { get; protected set; }
        public virtual void SetBase64Data(string data)
        {
            this.base64Data = data;
        }
    }
    [DataContract]
    public class UploadFile : AllFile
    {
        
    }
     
    ServiceReference.UploadFile obj = new ServiceReference.UploadFile();
    obj.SetBase64Data("data");
    AllFile file = (UploadFile)obj;
