    public void Process(BundleContext context, BundleResponse response)
    { 
        string myContent = "";
        foreach(var variable in myCustomVariables)
             myContent += String.Format("@{0}={1};", variable.Name, variable.Value);
        
        response.Content = dotless.Core.Less.Parse(myContent + response.Content);
        _cssMinify.Process(context, response);
    }
