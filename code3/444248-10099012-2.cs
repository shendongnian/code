    public class MyCustomVirtualFile : System.Web.Hosting.VirtualFile
    {
        private string _virtualPath;
        public MyCustomVirtualFile(string virtualPath) { _virtualPath = virtualPath }
        public override System.IO.Stream Open()
        {
            //You'll need some method to tie a virtual path to an assembly
            //Then load the file from the assembly and return as a Stream
            Assembly assembly = Foo.GetAssemblyByVirtualPath(_virtualPath);
            string fileName = Foo.GetFileNameFromVirtualPath(_virtualPath);
            return assembly.GetManifestresourceStream(fileName);
        }
    }
