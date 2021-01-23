    [WebService]
    public class ExampleWebService
    {
        public CredentialContainer Container { get; set; }
        [WebMethod]
        [SoapHeader("Container")]
        public void PerformSomething(string value)
        {
            var actualWebServiceClient = new MyWebServiceClient(Container.Url, ...);
            actualWebServiceClient.SendValue(value);
        }
    }
    public class CredentialContainer : SoapHeader
    {
        public string Url { get; set; }
        ...
    }
