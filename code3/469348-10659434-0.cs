    interface IKernel
    {
        // Useful members, e.g. AvailableMemory, TotalMemory, etc.
    }
    class Kernel : IKernel
    {
        private readonly Lazy<FileManager> fileManager;  // Every kernel has 1 file manager
        public Kernel() { this.fileManager = new Lazy<FileManager>(() => new FileManager(this)); /* etc. */ }
        // implements the interface; members are overridable
    }
    class FileManager
    {
        private /*readonly*/ IKernel kernel;  // Every file manager belongs to 1 kernel
        public FileManager(IKernel kernel) { this.kernel = kernel; /* etc. */ }
    }  
