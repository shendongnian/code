    // Get the address of the first line.
    IntPtr ptr = bmpData.Scan0;
    // Declare an array to hold the bytes of the bitmap. 
    int bytes = Math.Abs(bmpData.Stride) * bmp.Height;
    byte[] rgbValues = new byte[bytes];
    // Copy the RGB values into the array.
    System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);
    // Set every third value to 255. A 24bpp bitmap will look red.   
    for (int counter = 2; counter < rgbValues.Length; counter += 3)
        rgbValues[counter] = 255;
    // Copy the RGB values back to the bitmap
    System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, bytes);
