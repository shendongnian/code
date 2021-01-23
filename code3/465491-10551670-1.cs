    void sensor_AllFramesReady(object sender, AllFramesReadyEventArgs e)
        {
            if (closing)
            {
                return;
            }
            //Get a skeleton
            Skeleton first =  GetFirstSkeleton(e);
            if (first == null)
            {
                return; 
            }
            //set scaled position
            //ScalePosition(headImage, first.Joints[JointType.Head]);
            ScalePosition(leftEllipse, first.Joints[JointType.HandLeft]);
            ScalePosition(rightEllipse, first.Joints[JointType.HandRight]);
            ScalePosition(leftknee, first.Joints[JointType.KneeLeft]);
            ScalePosition(rightknee, first.Joints[JointType.KneeRight]);
            GetCameraPoint(first, e); 
        }
        void GetCameraPoint(Skeleton first, AllFramesReadyEventArgs e)
        {
            using (DepthImageFrame depth = e.OpenDepthImageFrame())
            {
                if (depth == null ||
                    kinectSensorChooser1.Kinect == null)
                {
                    return;
                }
                
                //Map a joint location to a point on the depth map
                //head
                DepthImagePoint headDepthPoint =
                    depth.MapFromSkeletonPoint(first.Joints[JointType.Head].Position);
                //left hand
                DepthImagePoint leftDepthPoint =
                    depth.MapFromSkeletonPoint(first.Joints[JointType.HandLeft].Position);
                //right hand
                DepthImagePoint rightDepthPoint =
                    depth.MapFromSkeletonPoint(first.Joints[JointType.HandRight].Position);
                DepthImagePoint rightKnee =
                    depth.MapFromSkeletonPoint(first.Joints[JointType.KneeRight].Position);
                DepthImagePoint leftKnee =
                    depth.MapFromSkeletonPoint(first.Joints[JointType.KneeLeft].Position);
                //Map a depth point to a point on the color image
                //head
                ColorImagePoint headColorPoint =
                    depth.MapToColorImagePoint(headDepthPoint.X, headDepthPoint.Y,
                    ColorImageFormat.RgbResolution640x480Fps30);
                //left hand
                ColorImagePoint leftColorPoint =
                    depth.MapToColorImagePoint(leftDepthPoint.X, leftDepthPoint.Y,
                    ColorImageFormat.RgbResolution640x480Fps30);
                //right hand
                ColorImagePoint rightColorPoint =
                    depth.MapToColorImagePoint(rightDepthPoint.X, rightDepthPoint.Y,
                    ColorImageFormat.RgbResolution640x480Fps30);
                ColorImagePoint leftKneeColorPoint =
                    depth.MapToColorImagePoint(leftKnee.X, leftKnee.Y,
                    ColorImageFormat.RgbResolution640x480Fps30);
                ColorImagePoint rightKneeColorPoint =
                    depth.MapToColorImagePoint(rightKnee.X, rightKnee.Y,
                    ColorImageFormat.RgbResolution640x480Fps30);
                //Set location
                CameraPosition(headImage, headColorPoint);
                CameraPosition(leftEllipse, leftColorPoint);
                CameraPosition(rightEllipse, rightColorPoint);
                
                Joint LEFTKNEE = first.Joints[JointType.KneeLeft];
                Joint RIGHTKNEE = first.Joints[JointType.KneeRight];
                if ((LEFTKNEE.TrackingState == JointTrackingState.Inferred ||
                LEFTKNEE.TrackingState == JointTrackingState.Tracked) &&
                (RIGHTKNEE.TrackingState == JointTrackingState.Tracked ||
                RIGHTKNEE.TrackingState == JointTrackingState.Inferred))
                {
                    CameraPosition(rightknee, rightKneeColorPoint);
                    CameraPosition(leftknee, leftKneeColorPoint);
                }
                else if (LEFTKNEE.TrackingState == JointTrackingState.Inferred ||
                        LEFTKNEE.TrackingState == JointTrackingState.Tracked)
                {
                    CameraPosition(leftknee, leftKneeColorPoint);
                }
                else if (RIGHTKNEE.TrackingState == JointTrackingState.Inferred ||
                        RIGHTKNEE.TrackingState == JointTrackingState.Tracked)
                {
                    CameraPosition(rightknee, rightKneeColorPoint);
                }
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
      private void ScalePosition(FrameworkElement element, Joint joint)
        {
            //convert the value to X/Y
            //Joint scaledJoint = joint.ScaleTo(1280, 720); 
            
            //convert & scale (.3 = means 1/3 of joint distance)
            Joint scaledJoint = joint.ScaleTo(1280, 720, .3f, .3f);
            Canvas.SetLeft(element, scaledJoint.Position.X);
            Canvas.SetTop(element, scaledJoint.Position.Y); 
            
        }
