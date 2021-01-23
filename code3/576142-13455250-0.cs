    [OperationContract]
    public void InsertSomeData(MyData data){...}
    
    [DataContract]
    public class MyData{
    [DataMember]
    public string version{get;set;}
    [DataMember(IsRequired=true)]
    public int someId{get;set;}
    
    }
