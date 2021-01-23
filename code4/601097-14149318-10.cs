    [ServiceContract]
    public interface IMathRest
    {
    
         [OperationContract]
         [WebGet(UriTemplate = "/Add/{Number1}/{Number2}", RequestFormat = WebMessageFormat.Json,
                  ResponseFormat = WebMessageFormat.Json)]
         int AddRest(string Number1, string Number2);
    }
