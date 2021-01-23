    var fsw = new FileSystemWatcher("[folder]", "*.*") { IncludeSubdirectories = true};
    var fsw_processing = false;
    fsw.Deleted += (s, e) => 
    {
        fsw_processing = true;
        fsw.EnableRaisingEvents = false;
        //......
        fsw.EnableRaisingEvents = true;
        fsw_processing = false;
    };
    
    fsw.Changed += (s, e) => 
    {
        fsw_processing = true;
        fsw.EnableRaisingEvents = false;
        //......
        fsw.EnableRaisingEvents = true;
        fsw_processing = false;
    };
    
    //governor thread to check FileSystemWatcher is still connected. It seems to disconnects on network outages etc.
    Task.Run(() => 
    {
        if (fsw.EnableRaisingEvents == false && fsw_processing == false)
        {   
            fsw.EnableRaisingEvents = true;
        }
        System.Threading.Thread.Sleep(1000 * 10);//sleep 10 secs
    });
