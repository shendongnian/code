        void DeleteFileAndWait(string filepath)
        {
            var fw = new FileSystemWatcher(Path.GetDirectoryName(filepath), Path.GetFileName(filepath))
            {
                EnableRaisingEvents = true
            };
            var mre = new ManualResetEventSlim();
            fw.Deleted += (object sender, FileSystemEventArgs e) =>
            {
                mre.Set();
            };
            File.Delete(filepath);
            mre.Wait(30000);
        }
