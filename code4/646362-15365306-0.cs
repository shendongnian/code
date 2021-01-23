    public object BeforeSendRequest(ref Message request, IClientChannel channel)
    {
        HttpRequestMessageProperty prop;
        if (request.Properties.ContainsKey(HttpRequestMessageProperty.Name))
        {
            prop = (HttpRequestMessageProperty)request.Properties[HttpRequestMessageProperty.Name];
        }
        else
        {
            prop = new HttpRequestMessageProperty();
            request.Properties.Add(HttpRequestMessageProperty.Name, prop);
        }
        prop.Headers["Content-Type"] = "text/xml; charset=UTF-8";
        prop.Headers["PropertyOne"] = "One";
        prop.Headers["PropertyTwo"] = "Two";
        return null;
    }
