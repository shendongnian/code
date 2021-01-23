    private void OnSkeletonFrameReady(object sender, SkeletonFrameReadyEventArgs e)
    {
        using (SkeletonFrame skeletonFrame = e.OpenSkeletonFrame())
        {
            // do checks for capturing the appropriate skeleton.
            Messenger.Default.Send<SkeletonFrame>(skeletonFrame);
            // do more stuff if you need.
        }
    }
