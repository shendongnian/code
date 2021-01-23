    [ServiceContract]
    public interface IUpdater
    {
        [OperationContract]
        public FileModified[] GetUpdateInfo();
        [OperationContract]
        public string GetUpdateURL();
    }
    [DataContract]
    public class FileModified
    {
        [DataMember]
        public string Path;
        [DataMember]
        public DateTime Modified;
    }
    public class Updater : IUpdater
    {
        public FileModified[] GetUpdateInfo()
        {
            // Get the physical directory
            string updateDir = HostingEnvironment.MapPath("website.com/updater");
            IList<FileModified> updateInfo = new List<FileModified>();
            foreach (string path in Directory.GetFiles(updateDir))
            {
                FileModified fm = new FileModified();
                fm.Path = // You may need to adjust path so that it is local with respect to updateDir
                fm.Modified = new FileInfo(path).LastWriteTime;
                updateInfo.Add(fm);
            }
            return updateInfo.ToArray();
        }
        [OperationContract]
        public string GetUpdateURL(string[] files)
        {
            // You could use System.IO.Compression.ZipArchive and its
            // method CreateEntryFromFile. You create a ZipArchive by
            // calling ZipFile.Open. The name of the file should probably
            // be unique for the update session, to avoid that two concurrent
            // updates from different clients will conflict. You could also
            // cache the ZIP packages you create, in a way that if a future
            // update requires the same exact file you would return the same
            // ZIP.
            // You have to return the URL of the ZIP, not its local path on the
            // server. There may be several ways to do this, and they tend to
            // depend on the server configuration.
            return urlOfTheUpdate;
        }
    }
