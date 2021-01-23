      [ServiceContract]
      public interface IService
      {
        [OperationContract]
        SendMessage(Messageformat message);
      }
    
 
      [DataContract]
      public class Messageformat
      {    
         [DataMember]
         public Attributecollection prop1;
         [DataMember]
         public Input prop2;
         [DataMember]
         public output prop3;
      } 
      [DataContract]
      public class Attributecollection
      {
         [DataMember]
         public string name { get; set; }
         [DataMember]
         public int id { get; set; }
      }
      [DataContract]
      public class Input
      {
          [DataMember]
          public string soid { get; set; }
          [DataMember]
          public string itemname { get; set; }
          [DataMember]
          public int qty { get; set; }
      }
      [DataContract]
      public class output
      {
          [DataMember]
          public string soid { get; set; }
      }
