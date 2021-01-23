    var fsw = new FileSystemWatcher(@"c:\temp\");
    fsw.EnableRaisingEvents = true;
    var changedObs = 
      Observable.FromEventPattern<FileSystemEventHandler, FileSystemEventArgs>(
          dlgt => fsw.Changed += dlgt, 
          dlgt => fsw.Changed -= dlgt);
    var createdObs = 
      Observable.FromEventPattern<FileSystemEventHandler, FileSystemEventArgs>(
          dlgt => fsw.Created += dlgt, 
          dlgt => fsw.Created -= dlgt);
    
    var watcher = 
        from creation in createdObs
        from change in changedObs.Throttle(TimeSpan.FromSeconds(5))
        select change;
    var disp = watcher.Subscribe(evt => 
        {
            if(evt != null)
            {
                Console.WriteLine("{0}:{1}:{2}", 
                   evt.EventArgs.Name, 
                   evt.EventArgs.ChangeType, 
                   evt.EventArgs.FullPath);
            }
        });
    Console.ReadLine();
    disp.Dispose();        
