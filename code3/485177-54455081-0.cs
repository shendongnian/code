        public void CallingMethod() {
        
         using(FileSystemWatcher watcher = new FileSystemWatcher()) {
          //It may be application folder or fully qualified folder location
          watcher.Path = "Folder_Name";
        
          // Watch for changes in LastAccess and LastWrite times, and
          // the renaming of files or directories.
          watcher.NotifyFilter = NotifyFilters.LastAccess |
           NotifyFilters.LastWrite |
           NotifyFilters.FileName |
           NotifyFilters.DirectoryName;
        
          // Only watch text files.if you want to track other types then mentioned here
          watcher.Filter = "*.txt";
        
          // Add event handlers.for monitoring newly added files          
          watcher.Created += OnChanged;
        
        
          // Begin watching.
          watcher.EnableRaisingEvents = true;
        
         }
        
        
        }
        
        // Define the event handlers.
        private static void OnChanged(object source, FileSystemEventArgs e) {
        // Specify what is done when a file is  created with these properties below
        // e.FullPath , e.ChangeType
        }
