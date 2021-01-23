    #region Bitmap Making...
    // BmpBufferSize : a pure length of raw bitmap data without the header.
    // the 54 value here is the length of bitmap header.
    byte[] BitmapBytes = new byte[BmpBufferSize + 54];
    
    #region Bitmap Header
    // 0~2 "BM"
    BitmapBytes[0] = 0x42;
    BitmapBytes[1] = 0x4d;
    
    // 2~6 Size of the BMP file - Bit cound + Header 54
    Array.Copy(BitConverter.GetBytes(BmpBufferSize + 54), 0, BitmapBytes, 2, 4);
    
    // 6~8 Application Specific : normally, set zero
    Array.Copy(BitConverter.GetBytes(0), 0, BitmapBytes, 6, 2);
    
    // 8~10 Application Specific : normally, set zero
    Array.Copy(BitConverter.GetBytes(0), 0, BitmapBytes, 8, 2);
    
    // 10~14 Offset where the pixel array can be found - 24bit bitmap data always starts at 54 offset.
    Array.Copy(BitConverter.GetBytes(54), 0, BitmapBytes, 10, 4);
    #endregion
    
    #region DIB Header
    // 14~18 Number of bytes in the DIB header. 40 bytes constant.
    Array.Copy(BitConverter.GetBytes(40), 0, BitmapBytes, 14, 4);
    					
    // 18~22 Width of the bitmap.
    Array.Copy(BitConverter.GetBytes(image.Width), 0, BitmapBytes, 18, 4);
    
    // 22~26 Height of the bitmap.
    Array.Copy(BitConverter.GetBytes(image.Height), 0, BitmapBytes, 22, 4);
    
    // 26~28 Number of color planes being used
    Array.Copy(BitConverter.GetBytes(0), 0, BitmapBytes, 26, 2);
    
    // 28~30 Number of bits. If you don't know the pixel format, trying to calculate it with the quality of the video/image source.
    if (image.PixelFormat == System.Drawing.Imaging.PixelFormat.Format24bppRgb)
    {                        
    	Array.Copy(BitConverter.GetBytes(24), 0, BitmapBytes, 28, 2);
    }
    
    // 30~34 BI_RGB no pixel array compression used : most of the time, just set zero if it is raw data.
    Array.Copy(BitConverter.GetBytes(0), 0, BitmapBytes, 30, 4);
    
    // 34~38 Size of the raw bitmap data ( including padding )
    Array.Copy(BitConverter.GetBytes(BmpBufferSize), 0, BitmapBytes, 34, 4);
    
    // 38~46 Print resolution of the image, 72 DPI x 39.3701 inches per meter yields
    if (image.PixelFormat == System.Drawing.Imaging.PixelFormat.Format24bppRgb)
    {
    	Array.Copy(BitConverter.GetBytes(0), 0, BitmapBytes, 38, 4);
    	Array.Copy(BitConverter.GetBytes(0), 0, BitmapBytes, 42, 4);
    }
    
    // 46~50 Number of colors in the palette
    Array.Copy(BitConverter.GetBytes(0), 0, BitmapBytes, 46, 4);
    
    // 50~54 means all colors are important
    Array.Copy(BitConverter.GetBytes(0), 0, BitmapBytes, 50, 4);
    
    // 54~end : Pixel Data : Finally, time to combine your raw data, BmpBuffer in this code, with a bitmap header you've just created.
    Array.Copy(BmpBuffer as Array, 0, BitmapBytes, 54, BmpBufferSize);
    #endregion - bitmap header process
    #endregion - bitmap making process
