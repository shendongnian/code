    Dictionary<string, string> param = new Dictionary<string, string>();
    
    public void SetYourParameter(string parametrName, string paramValue)
    {
        param[parametrName] = paramValue;            
    }
    public string GetYourParameter(string parametrName)
    {
        // ContainKey ---> It returns value if the key was found
        if( param.ContainsKey(parametrName))
            return param[parametrName];
        else
            return null;
    }
