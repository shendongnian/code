    private Skeleton[] skeletons = new Skeleton[0];
    private void SensorSkeletonFrameReady(object sender, SkeletonFrameReadyEventArgs e)
    {
        Skeleton[] skeletons = new Skeleton[0];
        using (SkeletonFrame skeletonFrame = e.OpenSkeletonFrame())
        {
            if (skeletonFrame != null)
            {
                skeletons = new Skeleton[skeletonFrame.SkeletonArrayLength];
                skeletonFrame.CopySkeletonDataTo(skeletons);
            }
        }
    }
