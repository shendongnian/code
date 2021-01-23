    string resName = "resources/HistoryConnections.xml";  
    
    private static UnmanagedMemoryStream GetResourceStream(string resName)
            {
                var assembly = Assembly.GetExecutingAssembly();
                var strResources = assembly.GetName().Name + ".g.resources";
                var rStream = assembly.GetManifestResourceStream(strResources);
                var resourceReader = new ResourceReader(rStream);
                var items = resourceReader.OfType<DictionaryEntry>();
                var stream = items.First(x => (x.Key as string) == resName.ToLower()).Value;
                return (UnmanagedMemoryStream)stream;
            }
