    public void Plot(ExternalCommandData commandData, string[] files)
    {
      UIApplication uiApplication = commandData.Application;
    
      foreach (string file in files)
      {
        Document document = uiApplication.OpenAndActivateDocument(file);
        
        //Do action on active document
      }
    }
