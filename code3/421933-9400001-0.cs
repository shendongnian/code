    public void Load(Request request)
    {
        // Request will always supply an int that identifies the
        // request type, can be used as key in provider dictionary
        IXmlLoader xmlLoader;
        if(_providerDictionary.ContainsKey(request.RequestType))
        {
            xmlLoader = _providerDictionary[request.RequestType];
        }
        else 
        {
            xmlLoader =  //acquire from factory
            _providerDictionary.Add(request.RequestType, xmlLoader);
        }
        xmlLoader.Load(request);
    }
