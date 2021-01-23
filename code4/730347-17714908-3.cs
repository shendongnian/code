    public object PostData(string id, string data)
    {
        //Do Something with data
    }
    public interface IPostService
    {
        [OperationContract(Name = "PostData")]
        [WebInvoke(UriTemplate = "/PostData?id={id})]
        object PostData(string id, string data);
    }
