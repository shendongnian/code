    Image lastUneditedFrame;
    private void VideoSourcePlayer_NewFrame(object sender, ref Bitmap image)
        {
            lastUneditedFrame = image.Clone(new Rectangle(0, 0, image.Width, image.Height), image.PixelFormat);
            var graphics = Graphics.FromImage(image);
            // do the drawing of photo frame
            graphics.Dispose();
        }
    // on snapshot button click, simply call lastUneditedFrame.Save();
