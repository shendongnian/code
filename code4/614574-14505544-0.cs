    [DataContract]
    public class Response : IExtensibleDataObject
    {
        public Response()
        {
            Success = true;
            ErrorMessage = null;
        }
        [DataMember]
        public bool Success { get; set; }
        [DataMember]
        public string ErrorMessage { get; set; }
        public ExtensionDataObject ExtensionData { get; set; }
    }
    [DataContract]
    public class Response<TResult> : Response
    {
        [DataMember]
        public TResult Result { get; set; }
    }
