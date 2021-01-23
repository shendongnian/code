    interface IInfrastructureProvider
    {
        string PathForSavingFiles { get; }
    }
    class Program : IInfrastructureProvider
    {
        public string PathForSavingFiles { get; set; }
    }
    abstract class FileBase
    {
        private readonly IInfrastructureProvider provider;
    
        [ImportingConstructor]
        protected FileBase(IInfrastructureProvider provider)
        {
            this.provider = provider;   
        }
    
        public void Save()
        {
            Save(provider.PathForSavingFiles);
        }
    
        protected abstract void Save(string path);
    }
