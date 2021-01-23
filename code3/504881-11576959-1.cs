    public void RunNavigationScript(string filePath, NavigationObject navObject)
    {
        var engine = Python.CreateEngine();
        var scope = engine.CreateScope();
        
        scope.SetVariable("navigation", navObject);
        var source = engine.CreateScriptSourceFromFile(filePath);
        try
        {
            source.Execute(scope);
        }
        catch(Exception
        {
        }
    }
