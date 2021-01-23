    private void KinectAllFramesReady(object sender, AllFramesReadyEventArgs e)
        {            
            if (!((KinectSensor)sender).SkeletonStream.IsEnabled)
            {
                return;
            }
            using (SkeletonFrame skeletonFrame = e.OpenSkeletonFrame())
            {
                // Rest implementation
            }
}
