    void DeleteFileAndWait(string filepath, int timeout = 30000)
    {
        using (var fw = new FileSystemWatcher(Path.GetDirectoryName(filepath), Path.GetFileName(filepath)))
        using (var mre = new ManualResetEventSlim())
        {
            fw.EnableRaisingEvents = true;
            fw.Deleted += (object sender, FileSystemEventArgs e) =>
            {
                mre.Set();
            };
            File.Delete(filepath);
            mre.Wait(timeout);
        }
    }
