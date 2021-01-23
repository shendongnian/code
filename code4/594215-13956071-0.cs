    static List<string> files = new List<string>();
    static void MyMethod() {
        DirectoryInfo dir = new DirectoryInfo(folderBrowserDialog1.SelectedPath);
        ProcessFolder(dir.GetFileSystemInfos());
    }
    static void ProcessFolder(IEnumerable<FileSystemInfo> fsi) {
        foreach (FileSystemInfo info in fsi) {
            // We skip reparse points 
            if ((info.Attributes & FileAttributes.ReparsePoint) == FileAttributes.ReparsePoint) {
                Debug.WriteLine("Skipping reparse point '{0}'", info.FullName);
                return;
            }
            if ((info.Attributes & FileAttributes.Directory) == FileAttributes.Directory) {
                // If our FileSystemInfo object is a directory, we call this method again on the
                // new directory.
                try {
                    DirectoryInfo dirInfo = (DirectoryInfo)info;
                    ProcessFolder(dirInfo.GetFileSystemInfos());
                }
                catch (Exception ex) {
                    // Skipping any errors
                    Debug.WriteLine("{0}", ex.Message);
                    break;
                }
            } else {
                // If our FileSystemInfo object isn't a directory, we cast it as a FileInfo object, 
                // make sure it's not null, and add it to the list.
                var file = info as FileInfo;
                if (file != null) {
                    files.Add(file.FullName);
                }
            }
        }
    }
