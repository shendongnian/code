    using Microsoft.Research.Kinect.Nui;
    Runtime nui = Runtime.Kinects[0];
    nui.Initialize(RuntimeOptions.UseSkeletalTracking);
    nui.SkeletonFrameReady += new EventHandler<SkeletonFrameReadyEventArgs>(nui_SkeletonFrameReady);
    void nui_SkeletonFrameReady(object sender, SkeletonFrameReadyEventArgs e)
    {
        SkeletonFrame sf = e.SkeletonFrame;
        SkeletonData d = (from s in sf.Skeletons
                          where s.TrackingState == SkeletonTrackingState.Tracked
                          select s).FirstOrDefault();
         if (d != null)
         {
              SetHandPosition(imageCursor, d.Joints[JointID.HandLeft]);
         }
    }
    void SetHandPosition(FrameworkElement e, Joint joint)
    {
        Joint scaledJoint = Coding4Fun.Kinect.Wpf.SkeletalExtensions.ScaleTo(joint, 600, 400, 0.75f, 0.75f);
                        
        Canvas.SetLeft(e, scaledJoint.Position.X);
        Canvas.SetTop(e, scaledJoint.Position.Y);
    } 
