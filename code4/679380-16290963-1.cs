    static class Prefixes
    {
        const public string Basic = "{a}/{b}/{c}";
    }
    
    public interface IRestSerivce
    {
        [OperationContract]
        [WebGet( UriTemplate = Prefixes.Basic + "/someName01?param={val}" )]
        string Handler01( .. );
    }
