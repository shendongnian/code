      for(int i = 0; i < 50; i++)
      {
        Bitmap clone = (Bitmap) original.Clone();
        BitmapData data = clone.LockBits(new Rectangle(0, 0, clone.Width, clone.Height), ImageLockMode.ReadOnly, clone.PixelFormat);
        clone.UnlockBits(data);
        list.Add(clone);
      }
