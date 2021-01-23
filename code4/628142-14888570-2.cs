    [ServiceContract]
    public interface IUpdater
    {
        [OperationContract]
        public FileModified[] GetUpdateInfo();
        [OperationContract]
        public string CompressFileAndGetURL(string path);
    }
