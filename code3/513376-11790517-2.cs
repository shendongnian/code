        [ServiceContract(Namespace="http://services.yourcompany.com/Service/2012/08")]
        interface IMyService
        {
           [OperationContract]
           SomeReturnType ThisIsYourMethod(string input, int value, .....);
        }
        [DataContract(Namespace="http://data.yourcompany.com/Service/2012/08")]
        public class SomeReturnType
        {
           [DataMember] 
           public string Name { get; set; }
           [DataMember]
           public int Age { get; set; }  
        }
