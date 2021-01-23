    [ServiceContract(Namespace = "http://Somewhere.StackOverflow.Samples")]
    public interface IRemoteArchive
    {
        [OperationContract]
        void ChangeCollectionFrom(string filepath);
    }
    partial class RemoteArchiveWCFService : IRemoteArchive
    {
        public void ChangeCollectionFrom(string filepath)
        {
            // ...    
        }
    }
