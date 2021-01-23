    [ServiceContract]
    public interface IMyRequest
    {
        [OperationContract]
        [WebInvoke(
           UriTemplate = "Requests/GetID",
           Method = "POST",
           BodyStyle = WebMessageBodyStyle.Wrapped)]
        string GetId(MyRequest myRequest);
    ...
