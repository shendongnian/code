    public class FileSystemAssetService : IAssetService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly string rootPath;
        public FileSystemAssetService(IUnitOfWork unitOfWork, string rootPath)
        {
            this.unitOfWork = unitOfWork;
            this.rootPath = rootPath;
        }
    }
