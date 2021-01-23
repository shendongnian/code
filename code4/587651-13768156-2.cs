    public WindowB(KinectSensor sensor) {
        sensor.SkeletonFrameReady += OnSkeletonFrameReady;
    }
    private void OnSkeletonFrameReady(object sender, SkeletonFrameReadyEventArgs e)
    {
        using (SkeletonFrame skeletonFrame = e.OpenSkeletonFrame())
        {
            // do what you need
        }
    }
