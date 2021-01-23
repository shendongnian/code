    public object InvokeWebserviceCall(string wsdUrl, string actionUrl, string functionName,
            string domain, string username, string password, params object[] parameters)
        {
            ///todo: validate input
            var proxy = new DynamicWebServiceProxy();
            //credentials if needed
            if (!string.IsNullOrEmpty(domain))
            {
                proxy.Credentials = new NetworkCredential(username, password, domain);
            }
            else if (!string.IsNullOrEmpty(username))
            {
                proxy.Credentials = new NetworkCredential(username, password);
            }
            proxy.EnableMessageAccess = true;
            proxy.Wsdl = wsdUrl;
            //get type name
            var type = proxy.ProxyAssembly.GetTypes().SingleOrDefault(t => t.BaseType == typeof(SoapHttpClientProtocolExtended));
            if (type != null)
            {
                proxy.TypeName = type.Name;
            }
            proxy.MethodName = functionName;
            proxy.Url = new Uri(actionUrl);
            if (parameters != null)
            {
                parameters.ToList().ForEach(proxy.AddParameter);
            }
            object result = proxy.InvokeCall();
            return result;
        }
