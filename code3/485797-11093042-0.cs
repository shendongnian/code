    public class MyType
    {
        public string Status { get; set; }
    }
    [ServiceContract]
    public class Service
    {
        [WebGet(UriTemplate = "returndata?s={s}")]
        public MyType ReturnData(string s)
        {
            return new MyType { Status = "OK" };
        }
    }
