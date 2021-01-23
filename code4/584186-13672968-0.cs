    using (SkeletonFrame skeletonFrame = e.OpenSkeletonFrame())
    {
     if (skeletonFrame == null)
         return;
        if (skeletons == null || skeletons.Length != skeletonFrame.SkeletonArrayLength)
        {
            skeletons = new Skeleton[skeletonFrame.SkeletonArrayLength];
        }
        skeletonFrame.CopySkeletonDataTo(skeletons);
        if (skeletons.All(s => s.TrackingState == SkeletonTrackingState.NotTracked))
            return;
        Skeleton firstTrackedSkeleton = skeletons.Where(s => s.TrackingState == SkeletonTrackingState.Tracked).FirstOrDefault();
        CoordinateMapper cm = new CoordinateMapper(YourKinectSensor);
        ColorImagePoint colorPoint = cm.MapSkeletonPointToColorPoint(first.Joints[JointType.HandRight].Position, ColorImageFormat.RgbResolution640x480Fps30);
         //Here the variable colorPoint have the X and Y values that you need to position your cursor.
    }
