    public string AppGitHash
    {
        get
        {
            AssemblyInformationalVersionAttribute attribute = (AssemblyInformationalVersionAttribute)Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyInformationalVersionAttribute), false).FirstOrDefault();
            return attribute.InformationalVersion;
        }
    }
