    private void OnSkeletonFrameReady(object sender, SkeletonFrameReadyEventArgs e)
    {
        using (SkeletonFrame skeletonFrame = e.OpenSkeletonFrame())
        {
            if (skeletonFrame != null && skeletonFrame.SkeletonArrayLength > 0)
            {
                if (_skeletons == null || _skeletons.Length != skeletonFrame.SkeletonArrayLength)
                {
                    _skeletons = new Skeleton[skeletonFrame.SkeletonArrayLength];
                }
                skeletonFrame.CopySkeletonDataTo(_skeletons);
                // grab the tracked skeleton and set the playerIndex for use pulling
                // the depth data out for the silhouette.
                // TODO: this assumes only a single tracked skeleton, we want to find the
                // closest person out of the tracked skeletons (see above).
                this.playerIndex = -1;
                for (int i = 0; i < _skeletons.Length; i++)
                {
                    if (_skeletons[i].TrackingState != SkeletonTrackingState.NotTracked)
                    {
                        this.playerIndex = i+1;
                    }
                }
            }
        }
    }
    private void OnDepthFrameReady(object sender, DepthImageFrameReadyEventArgs e)
    {
        using (DepthImageFrame depthFrame = e.OpenDepthImageFrame())
        {
            if (depthFrame != null)
            {
                // check if the format has changed.
                bool haveNewFormat = this.lastImageFormat != depthFrame.Format;
                if (haveNewFormat)
                {
                    this.pixelData = new short[depthFrame.PixelDataLength];
                    this.depthFrame32 = new byte[depthFrame.Width * depthFrame.Height * Bgra32BytesPerPixel];
                    this.convertedDepthBits = new byte[this.depthFrame32.Length];
                }
                depthFrame.CopyPixelDataTo(this.pixelData);
                for (int i16 = 0, i32 = 0; i16 < pixelData.Length && i32 < depthFrame32.Length; i16++, i32 += 4)
                {
                    int player = pixelData[i16] & DepthImageFrame.PlayerIndexBitmask;
                    if (player == this.playerIndex)
                    {
                        convertedDepthBits[i32 + RedIndex] = 0x44;
                        convertedDepthBits[i32 + GreenIndex] = 0x23;
                        convertedDepthBits[i32 + BlueIndex] = 0x59;
                        convertedDepthBits[i32 + 3] = 0x66;
                    }
                    else if (player > 0)
                    {
                        convertedDepthBits[i32 + RedIndex] = 0xBC;
                        convertedDepthBits[i32 + GreenIndex] = 0xBE;
                        convertedDepthBits[i32 + BlueIndex] = 0xC0;
                        convertedDepthBits[i32 + 3] = 0x66;
                    }
                    else
                    {
                        convertedDepthBits[i32 + RedIndex] = 0x0;
                        convertedDepthBits[i32 + GreenIndex] = 0x0;
                        convertedDepthBits[i32 + BlueIndex] = 0x0;
                        convertedDepthBits[i32 + 3] = 0x0;
                    }
                }
                if (silhouette == null || haveNewFormat)
                {
                    silhouette = new WriteableBitmap(
                        depthFrame.Width,
                        depthFrame.Height,
                        96,
                        96,
                        PixelFormats.Bgra32,
                        null);
                    
                    SilhouetteImage.Source = silhouette;
                }
                silhouette.WritePixels(
                    new Int32Rect(0, 0, depthFrame.Width, depthFrame.Height),
                    convertedDepthBits,
                    depthFrame.Width * Bgra32BytesPerPixel,
                    0);
                Silhouette = silhouette;
                this.lastImageFormat = depthFrame.Format;
            }
        }
    }
