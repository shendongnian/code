    private string GetAdditionalVersionInfo()
    {
        var assembly = Assembly.GetEntryAssembly();
        var attributesFound = assembly.GetCustomAttributes(typeof(AssemblyInformationalVersionAttribute), true);
        var version = attributesFound.OfType<AssemblyInformationalVersionAttribute>().FirstOrDefault();
        return version != null ? version.InformationalVersion : String.Empty;
    }
