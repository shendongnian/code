     public class M
     {
         public string personName { get; set; }
         public string source { get; set; }
         public string address { get; set; }
     }
     [OperationContract]
     [WebInvoke(UriTemplate = "services/CreatePerson", RequestFormat = WebMessageFormat.Json, 
        ResponseFormat = WebMessageFormat.Json, Method = "POST")]
     string CreatePerson(M data);
