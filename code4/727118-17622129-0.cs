    private void Watcher_Changed(Object sender, FileSystemEVentArgs e)
        {
            while (true)
            {
                FileStream stream;
                try
                {
                    stream = File.Open(e.FullPath, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
                    // If this succeeds, the file is finished
                    Changed();
                }
                catch (IOException)
                {
                }
                finally
                {
                    if (stream != null) stream.Close();
                }
            }
        }
