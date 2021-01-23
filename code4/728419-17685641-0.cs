    /// <summary>
    /// override cache functionality in ScriptBundle to use 
    /// persistent cache instead of HttpApplication.Cache
    /// </summary>
    public class ScriptBundleUsingPersistentCaching : ScriptBundle
    {
        public ScriptBundleUsingPersistentCaching(string virtualPath)
            : base(virtualPath)
        { }
        public ScriptBundleUsingPersistentCaching(string virtualPath, string cdnPath)
            : base(virtualPath, cdnPath)
        { }
        public override BundleResponse CacheLookup(BundleContext context)
        {
            //custom cache read
        }
        public override void UpdateCache(BundleContext context, BundleResponse response)
        {
            //custom cache save
        }
    }
