    public Uri GetResourceUri(this Assembly asm, string resourceName)
    {
        Uri result = null;
        var assemblyName = new AssemblyName(asm.FullName).Name;
        result = new Uri(string.Format("/{0};component/{1}", assemblyName, resourceName), UriKind.Relative);
        return result;
    }
