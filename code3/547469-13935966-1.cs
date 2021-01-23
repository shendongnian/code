      Bitmap original = new Bitmap("Test.jpg");
      Bitmap clone = (Bitmap) original.Clone();
      BitmapData odata = original.LockBits(new Rectangle(0, 0, original.Width, original.Height), ImageLockMode.ReadWrite, original.PixelFormat);
      BitmapData cdata = clone.LockBits(new Rectangle(0, 0, clone.Width, clone.Height), ImageLockMode.ReadWrite, clone.PixelFormat);
      Assert.AreNotEqual(odata.Scan0, cdata.Scan0);
