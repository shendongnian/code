     string exeFile = Assembly.GetEntryAssembly().Location;
     string exeDir = Path.GetDirectoryName(exeFile); 
     string path = Path.Combine(exeDir, "Custom");
    
     using (DirectoryCatalog catalog = new DirectoryCatalog(path))
     {
           using (CompositionContainer container = new CompositionContainer(catalog))
           {
              container.ComposeParts(this);
           }
     }
