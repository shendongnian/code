    private void fileSystemWatcher_Created(object sender, FileSystemEventArgs e)
    {
        ThreadPool.QueueUserWorkItem((state) =>
        {
            //this is for gz files in case if gz file is not unpacked automatically by other app
            Thread.Sleep(5000);//i need to wait and check if gz was unpacked, if not, unpack it by myself, than txt watcher will catch that
            if (File.Exists(e.FullPath))
            {
                try
                {
                    byte[] dataBuffer = new byte[4096];
                    using (System.IO.Stream fs = new FileStream(e.FullPath, FileMode.Open, FileAccess.Read))
                    {
                        using (GZipInputStream gzipStream = new GZipInputStream(fs))
                        {
                            string fnOut = Path.Combine(path_to_watcher, Path.GetFileNameWithoutExtension(e.FullPath));
                            using (FileStream fsOut = File.Create(fnOut))
                            {
                                StreamUtils.Copy(gzipStream, fsOut, dataBuffer);
                            }
                        }
                    }
                }
                catch
                {
                }
            }
        });
    }
