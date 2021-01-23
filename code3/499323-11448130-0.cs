    [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Bare, 
    ResponseFormat = WebMessageFormat.Xml, 
    RequestFormat = WebMessageFormat.Xml, 
    URITemplate="/GetOne/{param1}")]
    public int GetOne(string param1, string param2)
    {
        return 1;
    }
