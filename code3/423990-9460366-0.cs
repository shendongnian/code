    namespace System.Web.Compilation
    {
        public abstract class ResourceProviderFactory
        {
            public abstract IResourceProvider CreateGlobalResourceProvider(string classKey);
            public abstract IResourceProvider CreateLocalResourceProvider(string virtualPath);
        }
    }
