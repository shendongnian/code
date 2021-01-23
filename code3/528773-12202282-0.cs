    public class LocationManager
    {
      // Events
      public event EventHandler<LocationUpdatedEventArgs> LocationUpdated = delegate { };
      // Private members
      Geolocator gl = null;
      ActionBlock<PositionChangedEventArgs> block = null;
      public void StartUpdating(CoreDispatcher dispatcher)
      {
        // Set up the block to raise our event on the UI thread.
        block = new ActionBlock<PositionChangedEventArgs>(
            args =>
            {
              LocationUpdated(this, new LocationUpdatedEventArgs(args.Position));
            },
            new ExecutionDataflowBlockOptions
            {
              TaskScheduler = TaskScheduler.FromCurrentSynchronizationContext(),
            });
        // Start the Geolocator, sending updates to the block.
        gl = new Geolocator();
        gl.PositionChanged += (sender, args) =>
        {
          block.Post(args);
        };
      }
    }
