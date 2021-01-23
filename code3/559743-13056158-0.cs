    private static void LoadServices()
    {
      // find currently executing assembly
      Assembly Wcurr = Assembly.GetExecutingAssembly();
    
      // get the directory where this app is running in
      string wCurrentLocation = Path.GetDirectoryName(Wcurr.Location);
    
      // enumerate over those assemblies
      foreach (string wAssemblyName in mAssemblies)
      {
        // load assembly just for inspection
        Assembly wAssemblyToInspect = null;
        try
        {
          wAssemblyToInspect = Assembly.LoadFrom(wCurrentLocation + "\\" + wAssemblyName);
        }
        catch (System.Exception ex)
        {
          Console.WriteLine("Unable to load assembly : {0}", wAssemblyName);
        }
    
    
        if (wAssemblyToInspect != null)
        {
          // find all types with the HostService attribute
          IEnumerable<Type> wTypes = wAssemblyToInspect.GetTypes().Where(t => Attribute.IsDefined(t, typeof(HostService), false));
    
          foreach (Type wType in wTypes)
          {
            ServiceHost wServiceHost = new ServiceHost(wType);
            wServiceHost.Open();
            mServices.Add(wServiceHost);
            Console.WriteLine("New Service Hosted : {0}", wType.Name);
          }
        }
      }
    
      Console.WriteLine("Services are up and running.");
    }
