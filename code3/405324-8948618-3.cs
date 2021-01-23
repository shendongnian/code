    public static string AssemblyTitle
    {
        get 
        {
            return Assembly.GetExecutingAssembly()
                           .GetCustomAttributes(typeof(AssemblyTitleAttribute), false)
                           .Cast<AssemblyTitleAttribute>()
                           .Select(a => a.Title)
                           .FirstOrDefault();
        }
    }
