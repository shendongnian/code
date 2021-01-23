            //Register the events
            var currentSyncContext = SynchronizationContext.Current;
            var backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += (_,__) =>
                                           {
                                               //some action in background
                                               currentSyncContext.Send((t) =>
                                                                           {
                                                                               //Action that raise the event
                                                                           }, null);
                                           };
            backgroundWorker.RunWorkerAsync();
