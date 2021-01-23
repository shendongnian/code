    static class Prefixes
    {
        public const string Basic = "{a}/{b}/{c}";
    }
    
    public interface IRestSerivce
    {
        [OperationContract]
        [WebGet( UriTemplate = Prefixes.Basic + "/someName01?param={val}" )]
        string Handler01( .. );
    }
