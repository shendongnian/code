    [ServiceContract]
    public interface ITestJson
    {
      [OperationContract, WebInvoke(Method = "GET", UriTemplate = "/Echo/{Text}",
        RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
      string Echo(string Text);
    }
    [ServiceContract]
    public interface ITestRest
    {
      [OperationContract, WebInvoke(Method = "GET", UriTemplate = "/Echo/{Text}",
        RequestFormat = WebMessageFormat.Xml, ResponseFormat = WebMessageFormat.Xml)]
      string Echo(string Text);
    }
    [ServiceContract]
    public interface ITestBoth
    {
      [OperationContract, WebInvoke(Method = "GET", UriTemplate = "/Echo?Text={Text}&Format=json",
        RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
      string EchoJ(string Text);
      [OperationContract, WebInvoke(Method = "GET", UriTemplate = "/Echo?Text={Text}&Format=xml",
        RequestFormat = WebMessageFormat.Xml, ResponseFormat = WebMessageFormat.Xml)]
      string EchoR(string Text);
    }
