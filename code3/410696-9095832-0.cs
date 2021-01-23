    public class ClassToTest
    {
        private readonly IDataRetriever _dataRetriever;
        public Foo(IDataRetriever dataRetriever)
        {
            _dataRetriever = dataRetriever;
        }
        public string MethodToTest(string regularExpression, string strategy)
        {
            string body = CreateHttpBody(regularExpression, strategy);
            byte[] result = _dataRetriever.RetrieveData(Encoding.UTF8.GetBytes(body));
            return ExtractResponse(Encoding.UTF8.GetString(result));
        }
    }
