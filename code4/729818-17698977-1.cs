      Bitmap myImage;
      ... 
      byte[] rgbValues = null;
    
      BitmapData data = myImage.LockBits(new Rectangle(0, 0, myImage.Width, myImage.Height), ImageLockMode.ReadOnly, value.PixelFormat);
    
      try {
        IntPtr ptr = data.Scan0;
        int bytes = Math.Abs(data.Stride) * myImage.Height;
        rgbValues = new byte[bytes];
        Marshal.Copy(ptr, rgbValues, 0, bytes);
      }
      finally {
        myImage.UnlockBits(data);
      }
    }
