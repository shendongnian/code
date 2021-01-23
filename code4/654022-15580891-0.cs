    public override void Update(GameTime gameTime)
    {
        // Debug.WriteLine("= UPDATE - SkeletonStreamRender");
        if (null == this.Chooser.Sensor || false == this.Chooser.Sensor.IsRunning || KinectStatus.Connected != this.Chooser.Sensor.Status)
        {
            return;
        }
        if (skeletonDrawn || !drawChk)
        {
            using (var skeletonFrame = this.Chooser.Sensor.SkeletonStream.OpenNextFrame(0))
                {
                if (null == skeletonData || skeletonData.Length != skeletonFrame.SkeletonArrayLength)
                {
                    skeletonData = new Skeleton[skeletonFrame.SkeletonArrayLength];
                }
                skeletonFrame.CopySkeletonDataTo(skeletonData);
                int counter = 0;
                foreach (Skeleton s in skeletonData)
                {
                    if (s.TrackingState == SkeletonTrackingState.Tracked)
                    {
                        playersID = s.TrackingId;
                        Skeleton skeleton = MoveTo2(s);
                        skeletonData[counter] = skeleton;
                        continue;
                    }
                    counter++;
                }
                skeletonDrawn = false;
            }
            [CUT]
