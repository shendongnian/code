    [Export(typeof(ILoader<List<Resource>>))]
    internal class ResourceLoader : Loader<List<Resource>>
    {
       [ImportingConstructor]
       public ResourceLoader(IDeserializer<List<Resource>> deserializer, FileResolver fileResolver) : base(deserializer, fileResolver)
       {
       }
    }
    
    [Export(typeof(ILoader<List<Project>>))]
    internal class ProjectLoader : Loader<List<Project>>
    {
       [ImportingConstructor]
       public ProjectLoader(IDeserializer<List<Project>> deserializer, FileResolver fileResolver) : base(deserializer, fileResolver)
       {
       }
    }
