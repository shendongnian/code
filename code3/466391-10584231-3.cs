    void nui_SkeletonFrameReady(object sender, SkeletonFrameReadyEventArgs e)
    {
        SkeletonFrame sf = e.SkeletonFrame;
    
        if (sf.TrackingState == SkeletalTrackingState.Tracked)
         {
              int ID1 = sf.TrackingID;
         }
