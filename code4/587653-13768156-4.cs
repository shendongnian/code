    public WindowB() {
        Messenger.Default.Register<SkeletonFrameReadyEventArgs>(this, OnSkeletonFrameReady);
    }
    private void OnSkeletonFrameReady(SkeletonFrameReadyEventArgs e)
    {
        // do what you need with the event arg, just as you would in a regular callback
    }
