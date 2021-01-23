    [OperationContract]
    [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Xml, RequestFormat = WebMessageFormat.Xml)]
    public int GetOne(XElement content)
    {
        string param1 = content.Elements().First(element => element.Name == "param1").Value;
        string param2 = content.Elements().First(element => element.Name == "param2").Value;
        return 1;
    }
