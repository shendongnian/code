    private MouseTracker tracker = new MouseTracker();
    ...
    //in your constructor
    example.MouseMove += tracker.HandleMouseMove;
    tracker.MouseMoveWithHistory += tracker_SomeLocalHandler;
