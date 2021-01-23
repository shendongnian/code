    [WebInvoke(Method="POST", BodyStyle=WebMessageBodyStyle.WrappedRequest, ResponseFormat=WebMessageFormat.Xml, RequestFormat= WebMessageFormat.Xml)]
    public int GetOne(string param1, string param2)
    {
       return 1;
    }
