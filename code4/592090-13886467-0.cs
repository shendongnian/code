    JointCollection _savedJoint;
    DateTime _savedJointTime;
    
    private void OnSkeletonFrameReady(object sender, SkeletonFrameReadyEventArgs e)
    {
        using (SkeletonFrame skeletonFrame = e.OpenSkeletonFrame())
        {
            if (skeletonFrame == null || skeletonFrame.SkeletonArrayLength == 0)
                return;
            // resize the skeletons array if needed
            if (_skeletons.Length != skeletonFrame.SkeletonArrayLength)
                _skeletons = new Skeleton[skeletonFrame.SkeletonArrayLength];
            // get the skeleton data
            skeletonFrame.CopySkeletonDataTo(_skeletons);
            foreach (var skeleton in _skeletons)
            {
                // skip the skeleton if it is not being tracked
                if (skeleton.TrackingState != SkeletonTrackingState.Tracked)
                    continue;
                // do other checks and actions if needed...
                    
                // save off the joint
                _savedJoint = skeleton.Joints[JointType.HandLeft];
                _savedJointTime = DateTime.Now;
            }
        }
    }
