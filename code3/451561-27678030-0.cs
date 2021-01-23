    private void ChooseSkeleton()
      {
        if (this.kinect != null && this.kinect.SkeletonStream != null)
            {
            if (!this.kinect.SkeletonStream.AppChoosesSkeletons)
            {
            this.kinect.SkeletonStream.AppChoosesSkeletons = true; // Ensure AppChoosesSkeletons is set
            }
    
            foreach (Skeleton skeleton in this.skeletonData.Where(s => s.TrackingState != SkeletonTrackingState.NotTracked))
            {
            int ID { get.skeleton[1]}//Get ID here
            }
    
          if (ID = 0)
          {
            this.kinect.SkeletonStream.ChooseSkeletons(ID); // Track this skeleton
          }
        }
      }
