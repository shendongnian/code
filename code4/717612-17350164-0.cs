      public static Byte[] BmpToArray(Bitmap value) {
          BitmapData data = value.LockBits(new Rectangle(0, 0, value.Width, value.Height),   ImageLockMode.ReadOnly, value.PixelFormat);
    
          try {
            IntPtr ptr = data.Scan0;
            int bytes = Math.Abs(data.Stride) * value.Height;
            byte[] rgbValues = new byte[bytes];
            Marshal.Copy(ptr, rgbValues, 0, bytes);
    
            return rgbValues;
          }
          finally {
            value.UnlockBits(data);
          }
        }
