    public interface ICustomInterface
    {
        int Property1 {get;set}
    }
    
    [DataContract]
    public class MyClass
    {
         [DataMember(Name="_myInterface")]
         public ICustomInterface MyInterface {get;set;}
    }
