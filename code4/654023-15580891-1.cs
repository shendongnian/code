    public override void Draw(GameTime gameTime)
        {
            // Debug.WriteLine("== DRAW - SkeletonStreamRender");
            // If the joint texture isn't loaded, load it now
            if (null == this.jointTexture)
            {
                this.LoadContent();
            }
            // If we don't have data, lets leave
            if (null == skeletonData || null == this.mapMethod)
            {
                return;
            }
            if (false == this.initialized)
            {
                this.Initialize();
            }
            this.SharedSpriteBatch.Begin();
            foreach (var skeleton in skeletonData)
            {
                if (playersID != skeleton.TrackingId)
                    continue;
                switch (skeleton.TrackingState)
                {
                    case SkeletonTrackingState.NotTracked:
                        // non tracciato
                        break;
                    case SkeletonTrackingState.Tracked:
                        // blocco la posizione Z
                        Skeleton skeleton = MoveTo2(skeletonTmp);
                        // Draw Bones
                        this.DrawBone(skeleton.Joints, JointType.Head, JointType.ShoulderCenter);
                        this.DrawBone(skeleton.Joints, JointType.ShoulderCenter, JointType.ShoulderLeft);
                        this.DrawBone(skeleton.Joints, JointType.ShoulderCenter, JointType.ShoulderRight);
                        this.DrawBone(skeleton.Joints, JointType.ShoulderCenter, JointType.Spine);
                        [CUT]
