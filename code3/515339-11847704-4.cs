        void sensor_AllFramesReady(object sender, AllFramesReadyEventArgs e)
        {
            if (closing)
            {
                return;
            }
            //Get a skeleton
            Skeleton first = GetFirstSkeleton(e);
            if (first == null)
            {
                return;
            }
            //set scaled position
            ScalePosition(headImage, first.Joints[JointType.Head]);
            ScalePosition(leftEllipse, first.Joints[JointType.HandLeft]);
            ScalePosition(rightEllipse, first.Joints[JointType.HandRight]);
            ScalePosition(leftknee, first.Joints[JointType.KneeLeft]);
            ScalePosition(rightknee, first.Joints[JointType.KneeRight]);
            GetCameraPoint(first, e);
        }
