    public class ResourceService : IResourceService
    {
        public ResourceService() {}
        
        public GetResourceValue(string resourceFileName, string resourceKey)
        {
             var resourceManager = new ResourceManager("Myresources", Assembly.Load("MyResourcesProjectName"));
             return resourceManager.GetString(resourceKey);
        }
    } 
