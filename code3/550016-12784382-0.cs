            var sync = SynchronizationContext.Current;
            BackgroundWorker w = new BackgroundWorker();
            w.DoWork+=(_, __)=>
                {                    
                    foreach (var item in collection)
                    {
                       //calculate other things
                       sync.Post(p => { ...Actualize UI code... }, null);                  
                    }
                 }, null);
                };
            w.RunWorkerAsync();
  
