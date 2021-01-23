    public class VirtualFile : IVirtualFile
    {
        public IVirtualDirectory Directory { get; private set; }
        public string Name { get; private set; }
        public string VirtualPath { get; private set; }
        public string RealPath { get; private set; }
        public bool IsDirectory { get; private set; }
        public DateTime LastModified { get; private set; }
        public IVirtualPathProvider VirtualPathProvider { get; private set; }
        public string Extension { get; private set; }
        public VirtualFile(IVirtualPathProvider virtualPathProvider, string filePath)
        {
            VirtualPathProvider = virtualPathProvider;
            VirtualPath = filePath;
            RealPath = HttpContext.Current.Server.MapPath(filePath);
        }
        public string GetFileHash()
        {
            throw new NotImplementedException();
        }
        public Stream OpenRead()
        {
            throw new NotImplementedException();
        }
        public StreamReader OpenText()
        {
            throw new NotImplementedException();
        }
        public string ReadAllText()
        {
            return File.ReadAllText(RealPath);
        }
    }
