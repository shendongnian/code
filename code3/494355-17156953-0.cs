    using System.Web.Hosting;
    using System.Web.Optimization;
    // a more fault-tolerant bundle that doesn't blow up if the file isn't there
    public class BundleRelaxed : Bundle
    {
        public BundleRelaxed(string virtualPath)
            : base(virtualPath)
        {
        }
        public new BundleRelaxed IncludeDirectory(string directoryVirtualPath, string searchPattern, bool searchSubdirectories)
        {
            var truePath = HostingEnvironment.MapPath(directoryVirtualPath);
            if (truePath == null) return this;
            var dir = new System.IO.DirectoryInfo(truePath);
            if (!dir.Exists || dir.GetFiles(searchPattern).Length < 1) return this;
            base.IncludeDirectory(directoryVirtualPath, searchPattern);
            return this;
        }
        public new BundleRelaxed IncludeDirectory(string directoryVirtualPath, string searchPattern)
        {
            return IncludeDirectory(directoryVirtualPath, searchPattern, false);
        }
    }
