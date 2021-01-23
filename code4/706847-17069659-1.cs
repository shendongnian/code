    private static string GetSource()
    {
        try
        {
            string source = AppDomain.CurrentDomain.GetData("Source") as string;
            if (!String.IsNullOrWhiteSpace(source))
                return source;
            
            var assembly = Assembly.GetEntryAssembly();
    
            // GetEntryAssembly() can return null when called in the context of a unit test project.
            // That can also happen when called from an app hosted in IIS, or even a windows service.
            if (assembly == null)
            {
                // From http://stackoverflow.com/a/14165787/279516:
                assembly = new StackTrace().GetFrames().Last().GetMethod().Module.Assembly;
            }
    
            return assembly.GetName().Name;
        }
        catch
        {
            return "Unknown";
        }
    }
