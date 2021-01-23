    public interface ITest
    {
        [OperationContract]
        [WebInvoke(Method = "*",
            UriTemplate = "/users",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        User AddOrUpdateUser(User user);
    }
