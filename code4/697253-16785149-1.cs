        private void ProcessFiles(object state) {
            FileWatchInfo toProcess = null;
            List<string> toRemove = new List<string>();
            lock (this.SyncRoot) {
                foreach (var info in this.fileInfos) {
                    //  You may want to sort your list by latest to avoid files being left in the queue for a long time
                    if (info.Value.Checksum == null) {
                        //  If this fires the watcher, it doesn't matter, but beware of big files,
                        //     which may mean you need to move this outside the lock
                        string md5Value;
                        using (var md5 = MD5.Create()) {
                            using (var stream = File.OpenRead(info.Value.FullName)) {
                                info.Value.Checksum =
                                    BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", "").ToLower();
                            }
                        }
                    }
                    //  Data store (myFileInfoStore) is code I haven't included - use a Dictionary which you remove files from
                    //   after a few minutes, or a permanent database to store file checksums
                    if ((info.Value.Processed && info.Value.ProcessedTime.AddSeconds(5) < DateTime.UtcNow) 
                       || myFileInfoStore.GetFileInfo(info.Value.FullName).Checksum == info.Value.Checksum) {
                        toRemove.Add(info.Key);
                    }
                    else if (!info.Value.Processed && !info.Value.IsProcessing 
                        && info.Value.LatestTime.AddSeconds(5) < DateTime.UtcNow) {
                        info.Value.IsProcessing = true;
                        toProcess = info.Value;
                        //  This processes one file at a time, you could equally add a bunch to a list for parallel processing
                        break;
                    }
                }
                foreach (var filePath in toRemove) {
                    this.fileInfos.Remove(filePath);
                }
            }
            if (toProcess != null)
            {
                ProcessFile(packageSettings, toProcess.FullName, new FileInfo(toProcess.FullName).Extension); 
            }
        }
