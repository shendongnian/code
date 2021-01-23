    public sealed class SecondaryTileUpdater : IBackgroundTask
    {
        public async void Run(IBackgroundTaskInstance taskInstance)
        {
            //HERE: request a deferral
            var deferral = taskInstance.GetDeferral();
    
            var list = await SecondaryTile.FindAllAsync(); // Here it fails :(
            foreach (SecondaryTile liveTile in list)
            {
                // Update Secondary Tiles
                // (...)
            }
            //HERE: indicate you are done with your async operations
            deferral.Complete();
        }
    }
