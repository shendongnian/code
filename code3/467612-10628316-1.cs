        public static class KinectExtensions
        {
            public static WriteableBitmap CreateLivePlayerRenderer(this KinectSensor sensor)
            {
                if (sensor.DepthStream.FrameWidth == 0)
                    throw new InvalidOperationException("Either open the depth stream before calling this method or use the overload which takes in the resolution that the depth stream will later be opened with.");
                return CreateLivePlayerRenderer(sensor, sensor.DepthStream.FrameWidth, sensor.DepthStream.FrameHeight);
            }
            public static WriteableBitmap CreateLivePlayerRenderer(this KinectSensor sensor, int depthWidth, int depthHeight)
            {
                AllFramesReadyEventArgs d = new AllFramesReadyEventArgs();
                using (DepthImageFrame depthImage = d.OpenDepthImageFrame())
                {
                    WriteableBitmap target = new WriteableBitmap(depthWidth, depthHeight, 96, 96, PixelFormats.Bgra32, null);
                    var depthRect = new System.Windows.Int32Rect(0, 0, depthWidth, depthHeight);
                    sensor.DepthFrameReady += (s, e) =>
                    {
                        Debug.Assert(depthImage.Height == depthHeight && depthImage.Width == depthWidth);
                    };
                    sensor.ColorFrameReady += (s, e) =>
                    {
                        // don't do anything if we don't yet have a depth image
                        DepthImageFrame colorImage = depthImage;
                        if (colorImage.BytesPerPixel == null) return;
                        byte[] color = new byte[sensor.ColorStream.FramePixelDataLength];
                        e.OpenColorImageFrame().CopyPixelDataTo(color);
                        byte[] output = new byte[depthWidth * depthHeight * 4];
                        // loop over each pixel in the depth image
                        int outputIndex = 0;
                        for (int depthY = 0, depthIndex = 0; depthY < depthHeight; depthY++)
                        {
                            for (int depthX = 0; depthX < depthWidth; depthX++, depthIndex += 2)
                            {
                                short[] bits = new short[colorImage.BytesPerPixel];
                                depthImage.CopyPixelDataTo(bits);
                                // combine the 2 bytes of depth data representing this pixel
                                short depthValue = (short)(bits[depthIndex] | (bits[depthIndex + 1] << 8));
                                // extract the id of a tracked player from the first bit of depth data for this pixel
                                int player = bits[depthIndex] & 7;
                                // find a pixel in the color image which matches this coordinate from the depth image
                                int colorX, colorY;
                                ColorImagePoint colorPoint = depthImage.MapToColorImagePoint(depthImage.Width, depthImage.Height, sensor.ColorStream.Format);
                                // ensure that the calculated color location is within the bounds of the image
                                colorX = colorPoint.X;
                                colorY = colorPoint.Y;
                                output[outputIndex++] = color[(4 * (colorX + (colorY * e.OpenColorImageFrame().Width))) + 0];
                                output[outputIndex++] = color[(4 * (colorX + (colorY * e.OpenColorImageFrame().Width))) + 1];
                                output[outputIndex++] = color[(4 * (colorX + (colorY * e.OpenColorImageFrame().Width))) + 2];
                                output[outputIndex++] = player > 0 ? (byte)255 : (byte)0;
                            }
                        }
                        target.WritePixels(depthRect, output, depthWidth * PixelFormats.Bgra32.BitsPerPixel / 8, 0);
                    };
                    return target;
                }
            }
        }
