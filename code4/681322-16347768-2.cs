    public static class BitmapExt
    {
        public static void ChangeColour(this Bitmap bmp, byte inColourR, byte inColourG, byte inColourB, byte outColourR, byte outColourG, byte outColourB)
        {
            // Specify a pixel format.
            PixelFormat pxf = PixelFormat.Format24bppRgb;
            // Lock the bitmap's bits.
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            BitmapData bmpData =
            bmp.LockBits(rect, ImageLockMode.ReadWrite,
                         pxf);
            // Get the address of the first line.
            IntPtr ptr = bmpData.Scan0;
            // Declare an array to hold the bytes of the bitmap. 
            // int numBytes = bmp.Width * bmp.Height * 3; 
            int numBytes = bmpData.Stride * bmp.Height;
            byte[] rgbValues = new byte[numBytes];
            // Copy the RGB values into the array.
            Marshal.Copy(ptr, rgbValues, 0, numBytes);
            // Manipulate the bitmap
            for (int counter = 0; counter < rgbValues.Length; counter += 3)
            {
                if (rgbValues[counter] == inColourR &&
                    rgbValues[counter + 1] == inColourG &&
                    rgbValues[counter + 2] == inColourB)
                 {
                    rgbValues[counter] = outColourR;
                    rgbValues[counter + 1] = outColourG;
                    rgbValues[counter + 2] = outColourB;
                 }
            }
            // Copy the RGB values back to the bitmap
            Marshal.Copy(rgbValues, 0, ptr, numBytes);
            // Unlock the bits.
            bmp.UnlockBits(bmpData);
        }
    }
