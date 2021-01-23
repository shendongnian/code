     // this event will be fired from the thread where FileSystemWatcher is running.
     private void fileSystemWatcher1_Changed(object sender, FileSystemEventArgs e)
     {
          // Call invoke on the current to form, so the LoadDataGrid
          // will be executed on the main UI thread.
          this.Invoke(new Action(()=> { 
               LoadDatagrid();
          }));                
     }
