    using (DepthImageFrame depthimageFrame = e.OpenDepthImageFrame())
            {
                if (depthimageFrame == null)
                {
                    return;
                }
                pixelData = new short[depthimageFrame.PixelDataLength];
                depthimageFrame.CopyPixelDataTo(pixelData);
                for (int x = 0; x < depthimageFrame.Width; x++)
                {
                    for (int y = 0; y < depthimageFrame.Height; y++)
                    {
                            SkeletonPoint p = sensor.MapDepthToSkeletonPoint(DepthImageFormat.Resolution640x480Fps30, x, y, pixelData[x + depthimageFrame.Width * y]);                        
                    }
                }
            }
