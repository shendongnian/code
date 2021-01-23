    void Main()
    {
        var pathToWatch = @"c:\temp\";
        var fsw = new FileSystemWatcher(pathToWatch);
        // set up observables for create and changed
        var changedObs = 
           Observable.FromEventPattern<FileSystemEventHandler, FileSystemEventArgs>(
              dlgt => fsw.Changed += dlgt, 
              dlgt => fsw.Changed -= dlgt);
        var createdObs = 
           Observable.FromEventPattern<FileSystemEventHandler, FileSystemEventArgs>( 
              dlgt => fsw.Created += dlgt, 
              dlgt => fsw.Created -= dlgt);
        
        // the longest we'll wait between last file write and calling it "changed"
        var maximumTimeBetweenWrites = TimeSpan.FromSeconds(1);
        // A "pulse" ticking off every 10ms (adjust this as desired)
        var timer = Observable
            .Timer(TimeSpan.Zero, TimeSpan.FromMilliseconds(10))
            .Select(i => DateTime.Now);
                    
        var watcher = 
            from creation in createdObs
            from change in changedObs
                // we only care about changes matching a create
                .Where(changeEvt => changeEvt.EventArgs.Name == creation.EventArgs.Name)
                // take latest of (pulse, changes) and select (event, time since last file write)
                .CombineLatest(timer, (evt, now) => new {
                        Change = evt, 
                        DeltaFromLast = now.Subtract(new FileInfo(evt.EventArgs.FullPath).LastWriteTime)})
                // skip all until we trigger than "time before considered changed" threshold
                .SkipWhile(evt => evt.DeltaFromLast < maximumTimeBetweenWrites)
                // Then lock on that until we change a diff file
                .Distinct(evt => evt.Change.EventArgs.FullPath)
            select change.Change;
    
        var disp = new CompositeDisposable();
        
        // to show creates
        disp.Add(
            createdObs.Subscribe(
               evt => Console.WriteLine("New file:{0}", 
                    evt.EventArgs.FullPath)));
        // to show "final changes"
        disp.Add(
            watcher.Subscribe(
               evt => Console.WriteLine("{0}:{1}:{2}", 
                     evt.EventArgs.Name, 
                     evt.EventArgs.ChangeType, 
                     evt.EventArgs.FullPath)));
    
        fsw.EnableRaisingEvents = true;
    
        var rnd = new Random();
        Enumerable.Range(0,10)
            .AsParallel()
            .ForAll(i => 
                {
                    var filename = Path.Combine(pathToWatch, "foo" + i + ".txt");
                    if(File.Exists(filename))
                        File.Delete(filename);
                            
                    foreach(var j in Enumerable.Range(0, 20))
                    {
                        var writer = File.AppendText(filename);
                        writer.WriteLine(j);
                        writer.Close();
                        Thread.Sleep(rnd.Next(500));
                    }
                });
                
        Console.WriteLine("Press enter to quit...");
        Console.ReadLine();
        disp.Dispose();        
    }
