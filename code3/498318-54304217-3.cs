    private readonly string ns;
    public EmbeddedTemplateManager(string @namespace)
    {
        ns = @namespace;
    }
    public ITemplateSource Resolve(ITemplateKey key)
    {
        var resourceName = $"{ns}.{key.Name}.cshtml";
        string content;
        using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
        using (var streamReader = new StreamReader(stream))
        {
            content = streamReader.ReadToEnd();
        }
        return new LoadedTemplateSource(content);
    }
    public ITemplateKey GetKey(string name, ResolveType resolveType, ITemplateKey context)
    {
        return new NameOnlyTemplateKey(name, resolveType, context);
    }
    public void AddDynamic(ITemplateKey key, ITemplateSource source)
    {
        throw new NotImplementedException("");
    }
