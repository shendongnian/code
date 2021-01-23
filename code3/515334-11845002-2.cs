    private void OnSkeletonFrameReady(object sender, SkeletonFrameReadyEventArgs e)
    {
               
        skelFrame = e.OpenSkeletonFrame();
        skeletons = new Skeleton[kinectSensor.SkeletonStream.FrameSkeletonArrayLength];          
                
        if (skelFrame != null)
        {
            skelFrame.CopySkeletonDataTo(skeletons);
            foreach (Skeleton skel in skeletons) {
            if (skel.TrackingState >= SkeletonTrackingState.Tracked)
            {
                //here's get the joints for each tracked skeleton
                SkeletonPoint rightHand = skel.Joints[JointType.HandRight].Position;
                ....    
             }
        }
    }
