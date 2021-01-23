    /**
     * Converts the ColorFrame of the Kinect v2 to an image applicable for Emgu CV
     */
        public static Image<Bgra, byte> ToImage(this ColorFrame frame)
        {
            int width = frame.FrameDescription.Width;
            int height = frame.FrameDescription.Height;
            PixelFormat format = PixelFormats.Bgr32;
            byte[] pixels = new byte[width * height * ((format.BitsPerPixel + 7) / 8)];
            if (frame.RawColorImageFormat == ColorImageFormat.Bgra)
            {
                frame.CopyRawFrameDataToArray(pixels);
            }
            else
            {
                frame.CopyConvertedFrameDataToArray(pixels, ColorImageFormat.Bgra);
            }
            Image<Bgra, byte> img = new Image<Bgra, byte>(width, height);
            img.Bytes = pixels;
            return img;
        }
