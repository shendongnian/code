    static  System.Reflection.Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
    {
        string defaultNameSpace = "...";
        string dllName = args.Name.Contains(',') ? args.Name.Substring(0, args.Name.IndexOf(',')) : args.Name.Replace(".dll", "");
        string resourceName = String.Format("{0}.{1}.dll", defaultNameSpace , dllName);
        using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
        {
             if (stream == null)  
                 return null;
             byte[] data = new byte[stream.Length];
             stream.Read(data, 0, data.Length);
             return Assembly.Load(data);
         }
     }
 
