    [ServiceContract]
    public interface IRestService
    {
      [OperationContract]
      [WebInvoke(Method = "GET", 
        ResponseFormat = WebMessageFormat.Xml, 
        BodyStyle = WebMessageBodyStyle.Wrapped, 
        UriTemplate = "xml/{id}")]
      String XmlData(String id);
    
      [OperationContract]
      [WebInvoke(Method = "GET", 
        ResponseFormat = WebMessageFormat.Json, 
        BodyStyle = WebMessageBodyStyle.Wrapped, 
        UriTemplate = "json/{id}")]
      String JsonData(String id);
    }
