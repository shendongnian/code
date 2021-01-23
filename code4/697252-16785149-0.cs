    // So, first thing to do is add a dictionary to store file info:
    
    internal class FileWatchInfo
    {
        public DateTime LatestTime { get; set; }
        public bool IsProcessing { get; set; }
        public string FullName { get; set; }
        public string Checksum { get; set; }
    }
    SortedDictionary<string, FileWatchInfo> fileInfos = new SortedDictionary<string, FileWatchInfo>();
    private readonly object SyncRoot = new object();
    
    //  Now, when you set up the watcher, also set up a [`Timer`][1] to monitor that dictionary.
    
    CreateFileWatcherEvent(new SSISPackageSetting{ FileWatchPath = "H:\\test"});
    int processFilesInMilliseconds = 5000;
    Timer timer = new Timer(ProcessFiles, null, processFilesInMilliseconds, processFilesInMilliseconds);
    
    // In FileCreated, don't process the file but add it to a list
    
    private void FileCreated(FileSystemEventArgs e) {
        var finf = new FileInfo(e.FullPath);
        DateTime latest = finf.LastAccessTimeUtc > finf.LastWriteTimeUtc
            ? finf.LastAccessTimeUtc : finf.LastWriteTimeUtc;
        latest = latest > finf.CreationTimeUtc ? latest : finf.CreationTimeUtc;
        //  Beware of issues if other code sets the file times to crazy times in the past/future
        lock (SyncRoot) {
            //  You need to work out what to do if you actually need to add this file again (i.e. someone
            //  has edited it in the 5 seconds since it was created, and the time it took you to process it)
            if (!this.fileInfos.ContainsKey(e.FullPath)) {
                FileWatchInfo info = new FileWatchInfo {
                    FullName = e.FullPath,
                    LatestTime = latest,
                    IsProcessing = false, Processed = false,
                    Checksum = null
                };
                this.fileInfos.Add(e.FullPath, info);
            }
        }
    }
