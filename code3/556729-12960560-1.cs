    private void DrawBonesAndJoints(Skeleton skeleton, DrawingContext drawingContext)
    {
        // Render Torso
        this.DrawBone(skeleton, drawingContext, JointType.Head, JointType.ShoulderCenter);
        this.DrawBone(skeleton, drawingContext, JointType.ShoulderCenter, JointType.ShoulderLeft);
        this.DrawBone(skeleton, drawingContext, JointType.ShoulderCenter, JointType.ShoulderRight);
        this.DrawBone(skeleton, drawingContext, JointType.ShoulderCenter, JointType.Spine);
        this.DrawBone(skeleton, drawingContext, JointType.Spine, JointType.HipCenter);
        this.DrawBone(skeleton, drawingContext, JointType.HipCenter, JointType.HipLeft);
        this.DrawBone(skeleton, drawingContext, JointType.HipCenter, JointType.HipRight);
        // Left Arm
        this.DrawBone(skeleton, drawingContext, JointType.ShoulderLeft, JointType.ElbowLeft);
        this.DrawBone(skeleton, drawingContext, JointType.ElbowLeft, JointType.WristLeft);
        this.DrawBone(skeleton, drawingContext, JointType.WristLeft, JointType.HandLeft);
        // Right Arm
        this.DrawBone(skeleton, drawingContext, JointType.ShoulderRight, JointType.ElbowRight);
        this.DrawBone(skeleton, drawingContext, JointType.ElbowRight, JointType.WristRight);
        this.DrawBone(skeleton, drawingContext, JointType.WristRight, JointType.HandRight);
        // Left Leg
        this.DrawBone(skeleton, drawingContext, JointType.HipLeft, JointType.KneeLeft);
        this.DrawBone(skeleton, drawingContext, JointType.KneeLeft, JointType.AnkleLeft);
        this.DrawBone(skeleton, drawingContext, JointType.AnkleLeft, JointType.FootLeft);
        // Right Leg
        this.DrawBone(skeleton, drawingContext, JointType.HipRight, JointType.KneeRight);
        this.DrawBone(skeleton, drawingContext, JointType.KneeRight, JointType.AnkleRight);
        this.DrawBone(skeleton, drawingContext, JointType.AnkleRight, JointType.FootRight);
 
        // Render Joints
        foreach (Joint joint in skeleton.Joints)
        {
            Brush drawBrush = null;
            if (joint.TrackingState == JointTrackingState.Tracked)
            {
                drawBrush = this.trackedJointBrush;                    
            }
            else if (joint.TrackingState == JointTrackingState.Inferred)
            {
                drawBrush = this.inferredJointBrush;                    
            }
            if (drawBrush != null)
            {
                drawingContext.DrawEllipse(drawBrush, null, this.SkeletonPointToScreen(joint.Position), JointThickness, JointThickness);
            }
        }
    }
