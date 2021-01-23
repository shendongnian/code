    Task screenshotManager; 
     
         private void StartScreenshotManager()
                {
                    screenshotManager = Task.Factory.StartNew(() => { ScreenshotManagerJob(); }, TaskCreationOptions.LongRunning);
                    screenshotManager.ContinueWith((t) => { ScreenshotManagerUpdateUI(); }, TaskScheduler.FromCurrentSynchronizationContext());
                }
        
                private void ScreenshotManagerUpdateUI()
                {
                    // ... UI update work here ... 
                }
        
                private void ScreenshotManagerJob()
                {
                 // your code
                 }
