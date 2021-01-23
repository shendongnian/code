    [ServiceContract]
    public interface IMyRequest
    {
        [OperationContract]
        [WebInvoke(
           UriTemplate = "Requests/GetID",
           Method = "POST",
           BodyStyle = WebMessageBodyStyle.Bare)]
        string GetId(MyRequest myRequest);
    ...
