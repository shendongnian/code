    private static void file_created(object sender, FileSystemEventArgs e)
    {
        if (e.ChangeType == WatcherChangeTypes.Created)
        {
            if (Directory.Exists(e.FullPath))
            {
                foreach (string file in Directory.GetFiles(e.FullPath))
                {
                    var eventArgs = new FileSystemEventArgs(
                        WatcherChangeTypes.Created,
                        Path.GetDirectoryName(file),
                        Path.GetFileName(file));
                    file_created(sender, eventArgs);
                }
            }
            else
            {
                Console.WriteLine("{0} created.",e.FullPath);
            }
        }
    }
