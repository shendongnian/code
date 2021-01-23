        private byte[] getBitmapRawBytes(Bitmap bmp)
    {
        Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
        System.Drawing.Imaging.BitmapData bmpData =
            bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
        // Get the address of the first line.
        IntPtr ptr = bmpData.Scan0;
        // Declare an array to hold the bytes of the bitmap.
        int bytes = Math.Abs(bmpData.Stride) * bmp.Height;
        byte[] rgbValues = new byte[bytes];
        // Copy the RGB values into the array.
        System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);
        // Unlock the bits.
        bmp.UnlockBits(bmpData);
        return rgbValues;
    }
    /// <summary>
    /// The bitmap and the texture should be same size.
    /// The Texture format should be B8G8R8A8_UNorm
    /// Bitmap pixelformat is read as PixelFormat.Format32bppArgb, so if this is the native format maybe speed is higher?
    /// </summary>
    /// <param name="bmp"></param>
    /// <param name="tex"></param>
    public void WriteBitmapToTexture(Bitmap bmp, GPUTexture tex)
    {
        System.Diagnostics.Debug.Assert(tex.Resource.Description.Format == Format.B8G8R8A8_UNorm);
        var bytes = getBitmapRawBytes(bmp);
        tex.SetTextureRawData(bytes);
    }
