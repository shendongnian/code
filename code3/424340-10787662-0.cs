    using DotRas;
    RasConnectionWatcher watcher = new RasConnectionWatcher();
    watcher.Connected += (sender, e) => { // Do something useful. };
    watcher.Disconnected += (sender, e) => { // Do something useful. };
    watcher.EnableRaisingEvents = true;
