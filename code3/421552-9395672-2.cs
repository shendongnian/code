	//this event fires when Color/Depth/Skeleton are synchronized
	void newSensor_AllFramesReady(object sender, AllFramesReadyEventArgs e)
	{
		//Get a skeleton
		Skeleton skeleton = GetFirstSkeleton(e);
		if (skeleton == null)
		{
			return;
		}
		else if (skeleton != null)
		{
			checkHand(skeleton.Joints[JointType.Head], skeleton.Joints[JointType.HandRight], skeleton.Joints[JointType.HandLeft]);
		}
	}
    Skeleton GetFirstSkeleton(AllFramesReadyEventArgs e)
    {
        using (SkeletonFrame skeletonFrameData = e.OpenSkeletonFrame())
        {
            if (skeletonFrameData == null)
            {
                return null;
            }
            skeletonFrameData.CopySkeletonDataTo(allSkeletons);
            //get the first tracked skeleton
            Skeleton first = (from s in allSkeletons
                                where s.TrackingState == SkeletonTrackingState.Tracked
                                select s).FirstOrDefault();
            return first;
        }
    }
	public void checkHand(Joint head, Joint rhand, Joint lhand)
	{
		if (rhand.Position.Y > head.Position.Y)
		{
			MessageBox.Show("Right hand up!");
		}
		else if (lhand.Position.Y > head.Position.Y)
		{
			MessageBox.Show("Left hand up!");
		}
	}
