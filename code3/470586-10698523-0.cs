    [ServiceContract]
    public interface ISampleService
    {
            [OperationContract]
            int sum(SampleData obj);
    }
    
    public class SampleService : ISampleService
    {
            public int sum(SampleData obj)
            {
               // logic here
            }
    }
    
    [DataContract]
    public class SampleData
    {
           [DataMember]
           public int i { get; set; }
           
           [DataMember]
           public int q { get; set; }
    }
