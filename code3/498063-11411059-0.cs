    private static void CopyBmpRegion(Bitmap image, Rectangle srcRect, Point destLocation)
    {
        //do some argument sanitising.
        if (!((srcRect.X >= 0 && srcRect.Y >= 0) && ((srcRect.X + srcRect.Width) <= image.Width) && ((srcRect.Y + srcRect.Height) <= image.Height)))
            throw new ArgumentException("Source rectangle isn't within the image bounds.");
    
        if ((destLocation.X < 0 || destLocation.X > image.Width) || (destLocation.Y < 0 || destLocation.Y > image.Height))
            throw new ArgumentException("Destination must be within the image.");
    
        // Lock the bits into memory
        BitmapData bmpData = image.LockBits(new Rectangle(Point.Empty, image.Size), ImageLockMode.ReadWrite, image.PixelFormat);
        int pxlSize = (bmpData.Stride / bmpData.Width); //calculate the pixel width (in bytes) of the current image.
        int src = 0; int dest = 0; //source/destination pixels.
    
        //account for the fact that not all of the source rectangle may be able to copy into the destination:
        int width = (destLocation.X + srcRect.Width) < image.Width ? srcRect.Width : (image.Width - (destLocation.X + srcRect.Width)); 
        int height = (destLocation.Y + srcRect.Height) < image.Height ? srcRect.Height : (image.Height - (destLocation.Y + srcRect.Height));
    
        //managed buffer to hold the current pixel data.
        byte[] buffer = new byte[pxlSize];
    
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                //calculate the start of the current source pixel and destination pixel.
                src = ((srcRect.Y + y) * bmpData.Stride) + ((srcRect.X + x) * pxlSize);
                dest = ((destLocation.Y + y) * bmpData.Stride) + ((destLocation.X + x) * pxlSize);
                        
                // Can replace this with unsafe code, but that's up to you.
                Marshal.Copy(new IntPtr(bmpData.Scan0.ToInt32() + src), buffer, 0, pxlSize);
                Marshal.Copy(buffer, 0, new IntPtr(bmpData.Scan0.ToInt32() + dest), pxlSize);
            }
        }
    
        image.UnlockBits(bmpData); //unlock the data.
    }
