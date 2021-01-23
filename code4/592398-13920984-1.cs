    public class PathProvider : IVirtualPathProvider
    {
        public IVirtualDirectory RootDirectory { get; private set; }
        public string VirtualPathSeparator { get; private set; }
        public string RealPathSeparator { get; private set; }
        public string CombineVirtualPath(string basePath, string relativePath)
        {
            throw new NotImplementedException();
        }
        public bool FileExists(string virtualPath)
        {
            throw new NotImplementedException();
        }
        public bool DirectoryExists(string virtualPath)
        {
            throw new NotImplementedException();
        }
        public IVirtualFile GetFile(string virtualPath)
        {
            return new VirtualFile(this, virtualPath);
        }
        public string GetFileHash(string virtualPath)
        {
            throw new NotImplementedException();
        }
        public string GetFileHash(IVirtualFile virtualFile)
        {
            throw new NotImplementedException();
        }
        public IVirtualDirectory GetDirectory(string virtualPath)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<IVirtualFile> GetAllMatchingFiles(string globPattern, int maxDepth = 2147483647)
        {
            throw new NotImplementedException();
        }
        public bool IsSharedFile(IVirtualFile virtualFile)
        {
            throw new NotImplementedException();
        }
        public bool IsViewFile(IVirtualFile virtualFile)
        {
            throw new NotImplementedException();
        }
    }
