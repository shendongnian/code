    private Dictionary<string, string> assemblyNameToFileMapping = new Dictionary<string, string>();
    
    private void Form1_Load(object sender, EventArgs e)
    {
        GetAssemblyNames();
        AppDomain currentDomain = AppDomain.CurrentDomain;
        currentDomain.AssemblyResolve += new ResolveEventHandler(MyResolveEventHandler);
    }
    
    private void GetAssemblyNames()
    {
      string folderPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "libs");
      foreach(string file in Directory.EnumerateFiles(folderPath, "*.dll"))
      {
         try
         {
             AssemblyName name = AssemblyName.GetAssemblyName(file);
             assemblyNameToFileMapping.Add(name.FullName, file);
         }
         catch { } // Just move on if we can't get the name.
      }
    }
    
    private Assembly MyResolveEventHandler(object sender, ResolveEventArgs args)
    {
        string file;
        if (assemblyNameToFileMapping.TryGetValue(args.Name, out file))
        {
           return Assembly.LoadFrom(file);
        }
        return null;
    }
