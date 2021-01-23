    public class Transfer
    {
        public Transfer(IInternalConfig internalConfig)
        {
            source = internalConfig.GetFileConnection("source");
            destination = internalConfig.GetFileConnection("destination");
        }
        //you should consider making these private or protected fields
        public virtual IFileConnection source { get; set; }
        public virtual IFileConnection destination { get; set; }
    
        public virtual void GetFile(IFileConnection connection, 
            string remoteFilename, string localFilename)
        {
            connection.Get(remoteFilename, localFilename);
        }
    
        public virtual void PutFile(IFileConnection connection, 
            string localFilename, string remoteFilename)
        {
            connection.Get(remoteFilename, localFilename);
        }
    
        public virtual void TransferFiles(string sourceName, string destName)
        {
            var tempName = Path.GetTempFileName();
            GetFile(source, sourceName, tempName);
            PutFile(destination, tempName, destName);
        }
    }
