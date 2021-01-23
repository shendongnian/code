    // lock the bitmap.
    var data = image.LockBits(
                  new Rectangle(0, 0, image.Width, image.Height), 
                  ImageLockMode.ReadWrite, image.PixelFormat);
    try
    {
        unsafe
        {
            // get a pointer to the data.
            byte* ptr = (byte*)data.Scan0;
            // loop over all the data.
            for (int i = 0; i < data.Height; i++)
            {
                for (int j = 0; j < data.Width; j++)
                {
                    operate with pixels.
                }
            }
        }
    }
    finally
    {
        // unlock the bits when done or when 
        // an exception has been thrown.
        image.UnlockBits(data);
    }
