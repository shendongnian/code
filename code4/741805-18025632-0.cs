    public interface ITest
    {
        [OperationContract]
        [WebInvoke(Method = "POST",
            UriTemplate = "/users",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        User AddUser(User user);
        [OperationContract]
        [WebInvoke(Method = "PUT",
            UriTemplate = "/users",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        User UpdateUser(User user);
    }
