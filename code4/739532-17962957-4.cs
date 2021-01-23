    [ServiceContract]
    public interface ISampleService
    {
        [OperationContract]
        [FaultContractAttribute(typeof(MyFaultMessage))]
        string SampleMethod(string msg);
    }
    
    [DataContract]
    public class MyFaultMessage
    {
        public MyFaultMessage(string message)
        {
            Message = message;
        }
        [DataMember]
        public string Message { get; set; }
    }
    
    class SampleService : ISampleService
    {
        public string SampleMethod(string msg)
        {
            throw new FaultException<MyFaultMessage>(new MyFaultMessage("An error occurred."));
        }        
    }
