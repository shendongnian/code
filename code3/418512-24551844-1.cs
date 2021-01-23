    [ServiceContract]
    public interface ITestMutliHeadService
    {
        [OperationContract]
        [WebInvoke(UriTemplate = "loadchildren")]
        ResponseDocument LoadChildren(IncomingDocument request);
        [OperationContract]
        [WebGet(UriTemplate = "daydetails")]
        DayDetails DayDetails();
        [OperationContract]
        [WebGet(UriTemplate = "test/{input}")]
        string Test(string input);
    }
    [ServiceContract]
    [XmlSerializerFormat]
    public interface ITestMutliHeadServiceSchemaCompliant : ITestMutliHeadService
    {
    }
