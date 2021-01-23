    protected void Application_Start() 
    { 
      ViewEngines.Engines.Clear(); 
      ViewEngines.Engines.Add(new RazorViewEngine()); 
      ViewEngines.Engines.Add(new WebFormViewEngine()); 
    } 
