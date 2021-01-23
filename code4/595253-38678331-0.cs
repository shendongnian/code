    [ServiceContract]
    public interface IExecFunction
    {
        [WebGet(UriTemplate = "/{function}/{args}", ResponseFormat=WebMessageFormat.Json)]
        [OperationContract]
        Result CalcThis(string function, string args);
    }
    // the result class that actsd as an container
    public class Result
    {
        public Double DoubleResult { get; set; }
        public Int32 IntResult { get; set; }
        public string Message { get; set; }
    }
