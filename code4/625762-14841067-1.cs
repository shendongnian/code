     public void Dispose()
     {
         foreach (FileSystemWatcher fsw in _openWatchers.Values)
         {
              fsw.Dispose();
         }
     }
