    private string GetClientIp(HttpRequestMessage request)
    {
        if (request.Properties.ContainsKey("MS_HttpContext"))
        {
            return ((HttpContext)request.Properties["MS_HttpContext"]).Request.UserHostAddress;
        }
        else if (request.Properties.ContainsKey(RemoteEndpointMessageProperty.Name))
        {
            RemoteEndpointMessageProperty prop;
            prop = (RemoteEndpointMessageProperty)this.Request.Properties[RemoteEndpointMessageProperty.Name];
            return prop.Address;
        }
        else
        {
            return null;
        }
    }
