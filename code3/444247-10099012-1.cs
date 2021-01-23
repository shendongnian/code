    public class YourCustomVirtualPathProvider : System.Web.Hosting.VirtualPathProvider
    {
        private const string RESERVED_PATH = "/components/external";
        public override bool FileExists(string virtualPath)
        {
            if (virtualPath.StartsWith(RESERVED_PATH))
                return true;
            else
                return base.FileExists(virtualPath);
        }
        public override VirtualFile GetFile(string virtualPath)
        {
            if (virtualPath.StartsWith(RESERVED_PATH))
                return new MyCustomVirtualFile(virtualPath);
            else
                return base.GetFile(virtualPath);
        }
        //You'll also need to override methods for directories, omitted for brevity.
    }
