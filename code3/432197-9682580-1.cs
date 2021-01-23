    [ServiceContract]
    public interface IService
    {
    	[OperationContract]
    	[WebInvoke(UriTemplate="/Update/{id}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
    	void Update(string id, Entity entity);
    }
