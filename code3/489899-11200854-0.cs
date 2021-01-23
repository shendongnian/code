    [MessageContract]
    public class Data 
    { 
        [MessageHeader(MustUnderstand = true)]
        public string Info { get; set; } 
     
        /// <summary> 
        /// This is the file stream that would be returned to client. 
        /// </summary> 
        [MessageBodyMember(Order = 1)]
        public Stream File { get; set; } 
    } 
     
    [ServiceContract()] 
    public interface IService 
    {            
        [OperationContract] 
        Data GetData(); 
    } 
