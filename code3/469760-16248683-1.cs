    BitmapData data = image.LockBits(new Rectangle(0, 0, width, height), 
         ImageLockMode.ReadOnly, PixelFormat.Gray8);
 
    byte* dataPtr = (byte*)data.Scan0;
 
    int rowPadding = data.Stride - (image.Width);
    // iterate over height (rows)
    for (int i = 0; i < height; i++)
    {
        // iterate over width (columns)
        for (int j = 0; j < width; j++)
        {
            // pixel value
            int value = dataPtr[0];
            
            // advance to next pixel
            dataPtr++;
   
        // at the end of each column, skip extra padding
        if (rowPadding > 0)
        {
            dataPtr += rowPadding;
        }
    }
    image.UnlockBits(data1);
